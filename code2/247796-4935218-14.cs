    class Program
    {
        class Profiler
        {
            private Stopwatch Stopwatch = new Stopwatch();
            public TimeSpan Elapsed { get { return Stopwatch.Elapsed; } }
            public void Start()
            {
                Reset();
                Stopwatch.Start();
            }
            public void Stop()
            {            
                Stopwatch.Stop();
            }
            public void Reset()
            {
                Stopwatch.Reset();
            }
        }
        static string suffix = "_sfx";
        static Profiler profiler = new Profiler();
        static List<string> input = new List<string>();
        static List<string> output = new List<string>();
        static void Main(string[] args)
        {
            GenerateSuffixedStrings();
            FindStringsWithSuffix_UsingSubString(input, suffix);
            Console.WriteLine("SubString:    {0}", profiler.Elapsed);
            FindStringsWithSuffix_UsingContains(input, suffix);
            Console.WriteLine("Contains:     {0}", profiler.Elapsed);
            FindStringsWithSuffix_UsingCompareInfo(input, suffix);
            Console.WriteLine("CompareInfo:  {0}", profiler.Elapsed);
            FindStringsWithSuffix_UsingEndsWith(input, suffix);
            Console.WriteLine("EndsWith:     {0}", profiler.Elapsed);
            FindStringsWithSuffix_UsingLastIndexOf(input, suffix);
            Console.WriteLine("LastIndexOf:  {0}", profiler.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void GenerateSuffixedStrings()
        {
            for (var i = 0; i < 100000; i++)
            {
                input.Add(Guid.NewGuid().ToString() + suffix);
            }
        }
        static void FindStringsWithSuffix_UsingSubString(IEnumerable<string> strings, string suffix)
        {
            output.Clear();
            profiler.Start();
            foreach (var s in strings)
            {
                if(s.Substring(s.Length - 4) == suffix)
                    output.Add(s);
            }
            profiler.Stop();
        }
        static void FindStringsWithSuffix_UsingContains(IEnumerable<string> strings, string suffix)
        {
            output.Clear();
            profiler.Start();
            foreach (var s in strings)
            {
                if (s.Contains(suffix))
                    output.Add(s);
            }
            profiler.Stop();
        }
        static void FindStringsWithSuffix_UsingCompareInfo(IEnumerable<string> strings, string suffix)
        {
            var ci = CompareInfo.GetCompareInfo("en-GB");
            output.Clear();
            profiler.Start();
            foreach (var s in strings)
            {
                if (ci.IsSuffix(s, suffix))
                    output.Add(s);
            }
            profiler.Stop();
        }
        static void FindStringsWithSuffix_UsingEndsWith(IEnumerable<string> strings, string suffix)
        {
            output.Clear();
            profiler.Start();
            foreach (var s in strings)
            {
                if (s.EndsWith(suffix))
                    output.Add(s);
            }
            profiler.Stop();
        }
        static void FindStringsWithSuffix_UsingLastIndexOf(IEnumerable<string> strings, string suffix)
        {
            output.Clear();
            profiler.Start();
            foreach (var s in strings)
            {
                if (s.LastIndexOf(suffix) == s.Length - 4)
                    output.Add(s);
            }
            profiler.Stop();
        }
    }
