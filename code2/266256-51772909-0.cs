    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace AreUniqueTest
    {
    class Program
    {
        const int Iterations = 1000;
        enum DupeLocation
        {
            None,
            Early,
            Center,
            Late,
        }
        enum SetSize
        {
            Tiny= 10,
            Small = 100,
            Medium = 1000,
            Large = 10000,
            Huge = 100000,
        }
        static void Main()
        {
            Dictionary<string, Func<IEnumerable<int>, bool>> functions = new Dictionary<string, Func<IEnumerable<int>, bool>>
            {
                {"Gluip", GetIsUniqueGluip},
                {"LukeH", GetIsUniqueLukeH },
                {"Jamiec", GetIsUniqueJamiec },
                {"MrKWatkins", GetIsUniqueMrKWatkins }
            };
            var output = new StringBuilder();
            Console.WriteLine("Function,SetSize,DupeLocation,TotalTicks,AverageTicks");
            output.AppendLine("Function,SetSize,DupeLocation,TotalTicks,AverageTicks");
            foreach (SetSize size in Enum.GetValues(typeof(SetSize)))
            {
                var sizevalue = (int) size;
                foreach (DupeLocation location in Enum.GetValues(typeof(DupeLocation)))
                {
                    var data = CreateTestData((int)size, location);
                    foreach (string functionKey in functions.Keys)
                    {
                        var ticks = RunSet(functions[functionKey], data, Iterations);
                        var avg = ticks / Iterations;
                        Console.WriteLine($"{functionKey},{sizevalue},{location},{ticks},{avg}");
                        output.AppendLine($"{functionKey},{sizevalue},{location},{ticks},{avg}");
                    }
                }
            }
            File.WriteAllText("output.csv", output.ToString());
            Process.Start("output.csv");
        }
        static long RunSet<T>(Func<IEnumerable<T>, bool> getIsUnique, IEnumerable<T> values, int iterations)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < iterations; i++)
            {
                getIsUnique.Invoke(values);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        static bool GetIsUniqueLukeH<T>(IEnumerable<T> values)
        {
            var set = new HashSet<T>();
            foreach (T item in values)
            {
                if (!set.Add(item))
                    return false;
            }
            return true;
        }
        static bool GetIsUniqueGluip<T>(IEnumerable<T> values)
        {
            return values.Count() == values.Distinct().Count();
        }
        static bool GetIsUniqueJamiec<T>(IEnumerable<T> list)
        {
            var hs = new HashSet<T>();
            return list.All(hs.Add);
        }
        static bool GetIsUniqueMrKWatkins<T>(IEnumerable<T> values)
        {
            HashSet<T> hashSet = new HashSet<T>();
            foreach (var value in values)
            {
                if (hashSet.Contains(value))
                {
                    return false;
                }
                hashSet.Add(value);
            }
            return true;
        }
        static int[] CreateTestData(int size, DupeLocation location)
        {
            var result = new int[size];
            Parallel.For(0, size, i => { result[i] = i; });
            return SetDupe(result, location);
        }
        static int[] SetDupe(int[] values, DupeLocation location)
        {
            switch (location)
            {
                case DupeLocation.Early:
                    values[1] = values[0];
                    break;
                case DupeLocation.Center:
                    var midpoint = values.Length / 2;
                    values[midpoint] = values[midpoint + 1];
                    break;
                case DupeLocation.Late:
                    values[values.Length - 1] = values[values.Length - 2];
                    break;
                // case DupeLocation.None: // do nothing.
            }
            return values;
        }
    }
    }
