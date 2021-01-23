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
                Test("Enumerable \"Loop\"", () => Enumerable.Range(0, digits1.Length).Sum(i => digits1[i] * digits2[i]));
                Test("Using Zip", () => digits1.Zip(digits2, (x, y) => x * y).Sum());
                Test("Using Indexed Select", () => digits1.Select((n, i) => n * digits2[i]).Sum());
                Test("Using Indexed Select with ElementAt", () => digits1.Select((n, i) => n * digits2.ElementAt(i)).Sum());
                
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
                Console.WriteLine();
            }
    
            static void Test<T>(string testName, Func<T> test, int iterations = 1000000)
            {
                Console.WriteLine(testName);
                var results = Enumerable.Repeat(0, iterations).Select(i =>
                {
                    var timer = System.Diagnostics.Stopwatch.StartNew();
                    test();
                    timer.Stop();
                    return timer;
                }).ToList();
                Console.WriteLine("Time(ms): {0,3}/{1,10}/{2,8}", results.Min(t => t.ElapsedMilliseconds), results.Average(t => t.ElapsedMilliseconds), results.Max(t => t.ElapsedMilliseconds));
                Console.WriteLine("Ticks:    {0,3}/{1,10}/{2,8}", results.Min(t => t.ElapsedTicks), results.Average(t => t.ElapsedTicks), results.Max(t => t.ElapsedTicks));
                Console.WriteLine();
            }
        }
    }
Regular Loop
Time(ms):   0/         0/       0
Ticks:      9/   9.59199/     744
Enumerable "Loop"
Time(ms):   0/  0.000312/      40
Ticks:     39/ 41.421216/  110705
Using Zip
Time(ms):   0/   0.00014/      25
Ticks:     56/  61.34977/   70383
Using Indexed Select
Time(ms):   0/     8E-05/      27
Ticks:     49/ 52.544376/   76312
Using Indexed Select with ElementAt
Time(ms):   0/  0.000192/      23
Ticks:    420/449.503175/   64545
