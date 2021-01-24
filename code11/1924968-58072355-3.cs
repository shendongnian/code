 static void Main(string[] args)
        {
            BenchmarkRunner.Run<LogReaderBenchmarks>();
            Console.ReadLine();
            return;
        }
Run below command in `PackageManagerConsole` to add nuget package:
Install-Package BenchmarkDotNet -Version 0.11.5
Test data generator looks like this:
public static class LogFilesGenerator {
        public static void GenerateLogFile(string location)
        {
            var sizeBytes = 512*1024*1024; // 512MB
            var line = new StringBuilder();
            using (var f = new StreamWriter(location))
            {
                for (long z = 0; z < sizeBytes; z += line.Length)
                {
                    line.Clear();
                    line.Append($"{z}: {DateTime.UtcNow.TimeOfDay.ToString(@"hh\:mm\:ss\.fff")} - ");
                    for (var l = -1; l < z % 3; l++)
                        line.AppendLine(Guid.NewGuid().ToString());
                    f.WriteLine(line);
                }
                f.Close();
            }
        }
    }
### Reading file
And commentators pointed - that is very inefficient to read the whole file to memory, GC will be very unhappy, so you'll better read it line by line.
The simplest way to achieve that is just use `File.ReadLines()` method which returns you non-materialized enumerable - you'll read the file while you are iterating over it.
You can also read file asynchronously as explained [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/using-async-for-file-access). This is rather useless approach as I still merge everything to a single line, so I'm a bit speculating here when will comment on the results :)
|                Method | buffer |    Mean |       Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|---------------------- |------- |--------:|------------:|-----------:|----------:|----------:|
|      ReadFileToMemory |      ? | 1.919 s | 181000.0000 | 93000.0000 | 6000.0000 |   2.05 GB |
|   ReadFileEnumerating |      ? | 1.881 s | 314000.0000 |          - |         - |   1.38 GB |
| ReadFileToMemoryAsync |   4096 | 9.254 s | 248000.0000 | 68000.0000 | 6000.0000 |   1.92 GB |
| ReadFileToMemoryAsync |  16384 | 5.632 s | 215000.0000 | 61000.0000 | 6000.0000 |   1.72 GB |
| ReadFileToMemoryAsync |  65536 | 3.499 s | 196000.0000 | 54000.0000 | 4000.0000 |   1.62 GB |
    [RyuJitX64Job]
    [MemoryDiagnoser]
    [IterationCount(1), InnerIterationCount(1), WarmupCount(0), InvocationCount(1), ProcessCount(1)]
    [StopOnFirstError]
    public class LogReaderBenchmarks
    {
        string file = @"C:\Users\Admin\AppData\Local\Temp\tmp6483.tmp";
        [GlobalSetup()]
        public void Setup()
        {
            //file = Path.GetTempFileName();
            //Console.WriteLine(file);
            //LogFilesGenerator.GenerateLogFile(file);
        }
        //[GlobalCleanup]
        //public void Cleanup() => File.Delete(file);
        [Benchmark(Baseline = true)]
        public string ReadFileToMemory() => File.ReadAllText(file);
        [Benchmark]
        [Arguments(1024*4)]
        [Arguments(1024 * 16)]
        [Arguments(1024 * 64)]
        public async Task<string> ReadFileToMemoryAsync(int buffer) => await ReadTextAsync(file, buffer);
        [Benchmark]
        public int ReadFileEnumerating() => File.ReadLines(file).Select(l => l.Length).Max();
        private async Task<string> ReadTextAsync(string filePath, int bufferSize)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: bufferSize, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();
                byte[] buffer = new byte[bufferSize];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }
                return sb.ToString();
            }
        }
    }
As you can see `ReadFileEnumerating` is the fastest. It allocates the same amount of memory as `ReadFileToMemory` but it is all in Gen 0, so GC can collect it faster, max memory consumption is much smaller than `ReadFileToMemory`.
Async read does not give any performance gain. If you need throughput, don't use it.
### Split log entries
Regex is slow and memory hungry. Passing a huge string will make your application work slow. You can mitigate this problem and check each line of the file if it matches your Regex. You need to reconstruct the whole log entry though if it could be multiline.
Also you can introduce more efficient method that matches your string, check `customParseMatch` for example. I don't pretend it to be the most efficient, you may write a separate benchmark for predicate, but it already shows a good result comparing to `Regex`.
|                      Method |     Mean |       Gen 0 |       Gen 1 |     Gen 2 | Allocated |
|---------------------------- |---------:|------------:|------------:|----------:|----------:|
|                SplitByRegex | 26.393 s | 427000.0000 | 118000.0000 | 7000.0000 |   2.65 GB |
|       SplitByRegexIterating | 16.264 s | 176000.0000 |  88000.0000 | 1000.0000 |   2.05 GB |
| SplitByCustomParseIterating |  4.391 s | 964000.0000 | 150000.0000 | 1000.0000 |   6.67 GB |
    [RyuJitX64Job]
    [MemoryDiagnoser]
    [IterationCount(1), InnerIterationCount(1), WarmupCount(0), InvocationCount(1), ProcessCount(1)]
    [StopOnFirstError]
    public class LogParserBenchmarks
    {
        string file = @"C:\Users\Admin\AppData\Local\Temp\tmp6483.tmp";
        string[] lines;
        string text;
        Regex split_regex = new Regex(@"\s+(?=\d+: \d{2}:\d{2}:\d{2}\.\d{3} - )");
        [GlobalSetup()]
        public void Setup()
        {           
            lines = File.ReadAllLines(file);
            text = File.ReadAllText(file);
        }
        [Benchmark(Baseline = true)]
        public string[] SplitByRegex() => split_regex.Split(text);
        [Benchmark]
        public int SplitByRegexIterating() =>
            parseLogEntries(lines, split_regex.IsMatch).Count();
        [Benchmark]
        public int SplitByCustomParseIterating() =>
            parseLogEntries(lines, customParseMatch).Count();
        bool customParseMatch(string line)
        {
            var refinedLine = line.TrimStart();
            var parts = refinedLine.Split(':');
            if (parts.Length < 4) return false;
            if (!int.TryParse(parts[0], out var _)) return false;
            if (!TimeSpan.TryParseExact(parts[1], @" hh\:mm\:ss\.fff", CultureInfo.InvariantCulture, out var _)) return false;
            return true;
        }
        IEnumerable<string> parseLogEntries(IEnumerable<string> lines, Predicate<string> entryMatched)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var line in lines)
            {
                if (entryMatched(line) && builder.Length > 0)
                {
                    yield return builder.ToString();
                    builder.Clear();
                }
                builder.AppendLine(line);
            }
            if (builder.Length > 0)
                yield return builder.ToString();
        }
    }
### Parallelism 
If your log entries could be multi-line that is not trivial task and I'd leave it to other members to provide a code.
### Summary
So iterating over each line and using a custom parse function gives us the best results so far. Let's make a benchmark and check how much did we gain:
