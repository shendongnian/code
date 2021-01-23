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
                var results = Enumerable.Repeat(0, iterations).Select(i =>
                {
                    var timer = System.Diagnostics.Stopwatch.StartNew();
                    test();
                    timer.Stop();
                    return timer;
                }).ToList();
                Console.WriteLine("Time(ms): {0,3}/{1,10}/{2,8} ({3,10})", results.Min(t => t.ElapsedMilliseconds), results.Average(t => t.ElapsedMilliseconds), results.Max(t => t.ElapsedMilliseconds), results.Sum(t => t.ElapsedMilliseconds));
                Console.WriteLine("Ticks:    {0,3}/{1,10}/{2,8} ({3,10})", results.Min(t => t.ElapsedTicks), results.Average(t => t.ElapsedTicks), results.Max(t => t.ElapsedTicks), results.Sum(t => t.ElapsedTicks));
                Console.WriteLine();
            }
        }
    }
Regular Loop
Iterations: 1000000
Time(ms):   0/         0/       0 (         0)
Ticks:      8/  8.736593/     709 (   8736593)
Enumerable "Loop"
Iterations: 1000000
Time(ms):   0/  0.000322/      41 (       322)
Ticks:     27/ 29.376282/  115717 (  29376282)
Using Zip
Iterations: 1000000
Time(ms):   0/   0.00016/      35 (       160)
Ticks:     43/ 47.286081/   97098 (  47286081)
Using Indexed Select
Iterations: 1000000
Time(ms):   0/   8.2E-05/      25 (        82)
Ticks:     34/ 39.201637/   71290 (  39201637)
Using Indexed Select with ElementAt
Iterations: 1000000
Time(ms):   0/  0.000196/      23 (       196)
Ticks:    404/ 440.74142/   64111 ( 440741420)
Parallel Enumerable "Loop"
Iterations: 1000000
Time(ms):   0/  0.000145/      21 (       145)
Ticks:    139/329.814908/   60641 ( 329814908)
Using Parallel Zip
Iterations: 1000000
Time(ms):   0/  0.000135/      13 (       135)
Ticks:    161/ 314.33692/   38098 ( 314336920)
Using Parallel Indexed Select
Iterations: 1000000
Time(ms):   0/   0.00018/      15 (       180)
Ticks:    159/308.923577/   43565 ( 308923577)
Using Parallel Indexed Select with ElementAt
Iterations: 1000000
Time(ms):   0/  0.000293/      15 (       293)
Ticks:    292/462.179207/   43861 ( 462179207)
