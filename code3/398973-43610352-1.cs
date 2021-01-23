    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Horology;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;
    namespace StringIterationBenchmark
    {
        public class StringIteration
        {
            public static void Main(string[] args)
            {
                var config = new ManualConfig();
                config.Add(DefaultConfig.Instance);
                config.Add(Job.Default
                    .WithLaunchCount(1)
                    .WithIterationTime(TimeInterval.FromMilliseconds(500))
                    .WithWarmupCount(3)
                    .WithTargetCount(6)
                );
                BenchmarkRunner.Run<StringIteration>(config);
            }
            private readonly string _longString = BuildLongString();
            private static string BuildLongString()
            {
                var sb = new StringBuilder();
                var random = new Random();
                while (sb.Length < 10000)
                {
                    char c = (char)random.Next(char.MaxValue);
                    if (!Char.IsControl(c))
                        sb.Append(c);
                }
                return sb.ToString();
            }
            [Benchmark]
            public char Indexing()
            {
                char c = '\0';
                var longString = _longString;
                int strLength = longString.Length;
                for (int i = 0; i < strLength; i++)
                {
                    c |= longString[i];
                }
                return c;
            }
            [Benchmark]
            public char IndexingOnArray()
            {
                char c = '\0';
                var longString = _longString;
                int strLength = longString.Length;
                char[] charArray = longString.ToCharArray();
                for (int i = 0; i < strLength; i++)
                {
                    c |= charArray[i];
                }
                return c;
            }
            [Benchmark]
            public char ForEachOnArray()
            {
                char c = '\0';
                var longString = _longString;
                foreach (char item in longString.ToCharArray())
                {
                    c |= item;
                }
                return c;
            }
            [Benchmark]
            public char ForEach()
            {
                char c = '\0';
                var longString = _longString;
                foreach (char item in longString)
                {
                    c |= item;
                }
                return c;
            }
            [Benchmark]
            public unsafe char Unsafe()
            {
                char c = '\0';
                var longString = _longString;
                int strLength = longString.Length;
                fixed (char* p = longString)
                {
                    var p1 = p;
                    for (int i = 0; i < strLength; i++)
                    {
                        c |= *p1;
                        p1++;
                    }
                }
                return c;
            }
        }
    }
