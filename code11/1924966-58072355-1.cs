 static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<LogReaderBenchmarks>();
            Console.WriteLine(summary);
            Console.ReadLine();
            return;
        }
Test data generator looks like this:
public static class LogFilesGenerator {
        public static void GenerateLogFile(string location)
        {
            var sizeBytes = 1L*1024*1024*1024; // 1GB
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
You can also read file asynchronously as explained [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/using-async-for-file-access). 
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
|                Method | buffer |    Mean |       Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|---------------------- |------- |--------:|------------:|-----------:|----------:|----------:|
|      ReadFileToMemory |      ? | 1.919 s | 181000.0000 | 93000.0000 | 6000.0000 |   2.05 GB |
|   ReadFileEnumerating |      ? | 1.881 s | 314000.0000 |          - |         - |   1.38 GB |
| ReadFileToMemoryAsync |   4096 | 9.254 s | 248000.0000 | 68000.0000 | 6000.0000 |   1.92 GB |
| ReadFileToMemoryAsync |  16384 | 5.632 s | 215000.0000 | 61000.0000 | 6000.0000 |   1.72 GB |
| ReadFileToMemoryAsync |  65536 | 3.499 s | 196000.0000 | 54000.0000 | 4000.0000 |   1.62 GB |
As you can see `ReadFileEnumerating` is the fastest. It allocates the same amount of memory as `ReadFileToMemory` but it is all in Gen 0, so GC can collect it faster, max memory consumption is much smaller than `ReadFileToMemory`.
### Split log entries
