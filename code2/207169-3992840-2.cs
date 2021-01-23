    using System;
    using System.Linq;
    
    namespace Testbench
    {
        class Program
        {
            static void Main(string[] args)
            {
                var digits1 = Enumerable.Range(0, 500).ToArray();
                var digits2 = digits1.ToArray(); // create a copy
    
                Test("Regular Loop", () =>
                {
                    int result = 0;
                    for (int i = 0; i < digits1.Length; i++)
                    {
                        result += digits1[i] * digits2[i];
                    }
                    return result;
                });
    
                // using LINQ
                Test("Enumerable \"Loop\"", () => Enumerable.Range(0, digits1.Length).Sum(i => digits1[i] * digits2[i]));
                Test("Using Zip", () => digits1.Zip(digits2, (x, y) => x * y).Sum());
                Test("Using Indexed Select", () => digits1.Select((n, i) => n * digits2[i]).Sum());
                Test("Using Indexed Select with ElementAt", () => digits1.Select((n, i) => n * digits2.ElementAt(i)).Sum());
    
                // using PLINQ
                Test("Parallel Enumerable \"Loop\"", () => ParallelEnumerable.Range(0, digits1.Length).Sum(i => digits1[i] * digits2[i]));
                Test("Using Parallel Zip", () => digits1.AsParallel().Zip(digits2.AsParallel(), (x, y) => x * y).Sum());
                Test("Using Parallel Indexed Select", () => digits1.AsParallel().Select((n, i) => n * digits2[i]).Sum());
                Test("Using Parallel Indexed Select with ElementAt", () => digits1.AsParallel().Select((n, i) => n * digits2.ElementAt(i)).Sum());
    
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
                Console.WriteLine();
            }
    
            static void Test<T>(string testName, Func<T> test, int iterations = 1000000)
            {
                Console.WriteLine(testName);
                Console.WriteLine("Iterations: {0}", iterations);
                var results = Enumerable.Repeat(0, iterations).Select(i => new System.Diagnostics.Stopwatch()).ToList();
                results.ForEach(t =>
                {
                    t.Start();
                    test();
                    t.Stop();
                });
                Console.WriteLine("Time(ms): {0,3}/{1,10}/{2,8} ({3,10})", results.Min(t => t.ElapsedMilliseconds), results.Average(t => t.ElapsedMilliseconds), results.Max(t => t.ElapsedMilliseconds), results.Sum(t => t.ElapsedMilliseconds));
                Console.WriteLine("Ticks:    {0,3}/{1,10}/{2,8} ({3,10})", results.Min(t => t.ElapsedTicks), results.Average(t => t.ElapsedTicks), results.Max(t => t.ElapsedTicks), results.Sum(t => t.ElapsedTicks));
                Console.WriteLine();
            }
        }
    }
