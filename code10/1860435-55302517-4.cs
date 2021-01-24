    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 500_000_000;
            int[] values = new int[N]; // 2 GB
            for (int nThreads = 1; nThreads < Environment.ProcessorCount; nThreads++)
            {
                SetArray(values, checkValue: 1, nTimes: 10, nThreads: nThreads);
                SetArray(values, checkValue: 2, nTimes: 10, nThreads: nThreads);
                SetArrayNoCheck(values, checkValue: 2, nTimes: 10, nThreads: nThreads);
            }
        }
    
        private static void SetArray(int[] values, int checkValue, int nTimes, int nThreads)
        {
            List<double> ms = new List<double>();
    
            for (int k = 0; k < nTimes; k++)  // set array values to 1
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = 1;
                }
    
                var sw = Stopwatch.StartNew();
                Action acc = () =>
                {
                    int tmp1 = 0;
                    for (int i = 0; i < values.Length; i++)
                    {
                        tmp1 = values[i];
                        if (tmp1 != checkValue)  // set only if not equal to checkvalue
                        {
                            values[i] = checkValue;
                        }
                    }
                };
    
                Parallel.Invoke(Enumerable.Repeat(acc, nThreads).ToArray());  // Let this run on 3 cores
    
                sw.Stop();
                ms.Add(sw.Elapsed.TotalMilliseconds);
                //  Console.WriteLine($"Set {values.Length * 4 / (1_000_000_000.0f):F1} GB of Memory in {sw.Elapsed.TotalMilliseconds:F0} ms. Initial Value 1. Set Value {checkValue}");
            }
            string descr = checkValue == 1 ? "Conditional Not Set" : "Conditional Set";
            Console.WriteLine($"{descr}, {ms.Average():F0}, ms, nThreads, {nThreads}");
    
        }
    
        private static void SetArrayNoCheck(int[] values, int checkValue, int nTimes, int nThreads)
        {
            List<double> ms = new List<double>();
            for (int k = 0; k < nTimes; k++)  // set array values to 1
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = 1;
                }
    
                var sw = Stopwatch.StartNew();
                Action acc = () =>
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                            values[i] = checkValue;
                    }
                };
    
                Parallel.Invoke(Enumerable.Repeat(acc, nThreads).ToArray());  // Let this run on 3 cores
    
                sw.Stop();
                ms.Add(sw.Elapsed.TotalMilliseconds);
                //Console.WriteLine($"Unconditional Set {values.Length * 4 / (1_000_000_000.0f):F1} GB of Memory in {sw.Elapsed.TotalMilliseconds:F0} ms. Initial Value 1. Set Value {checkValue}");
            }
            Console.WriteLine($"Unconditional Set, {ms.Average():F0}, ms, nThreads, {nThreads}");
        }
    }
