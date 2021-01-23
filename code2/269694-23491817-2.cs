    using System;
    using System.Diagnostics;
    namespace ProfileMathMax
    {
      class Program
      {
        static double controlTotalSeconds;
        const int InnerLoopCount = 100000;
        const int OuterLoopCount = 1000000000 / InnerLoopCount;
        static int[] values = new int[InnerLoopCount];
        static int total = 0;
        static void ProfileBase()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int maxValue;
            for (int j = 0; j < OuterLoopCount; j++)
            {
                maxValue = 0;
                for (int i = 0; i < InnerLoopCount; i++)
                {
                    // baseline
                    total += values[i];
                }
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Control - Empty Loop - " + controlTotalSeconds + " seconds");
        }
        
        static void ProfileMathMax()
        {
            int maxValue;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int j = 0; j < OuterLoopCount; j++)
            {
                maxValue = 0;
                for (int i = 0; i < InnerLoopCount; i++)
                {
                    maxValue = Math.Max(values[i], maxValue);
                    total += values[i];
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Max(a, max) - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");
        }
        static void ProfileMathMaxReverse()
        {
            int maxValue;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int j = 0; j < OuterLoopCount; j++)
            {
                maxValue = 0;
                for (int i = 0; i < InnerLoopCount; i++)
                {
                    maxValue = Math.Max(maxValue, values[i]);
                    total += values[i];
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Max(max, a) - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");
        }
        static void ProfileInline()
        {
            int maxValue = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int j = 0; j < OuterLoopCount; j++)
            {
                maxValue = 0;
                for (int i = 0; i < InnerLoopCount; i++)
                {
                    maxValue = maxValue > values[i] ? values[i] : maxValue;
                    total += values[i];
                }
            }
            stopwatch.Stop();
            Console.WriteLine("max = max > a ? a : max: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");
        }
        static void ProfileIf()
        {
            int maxValue = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int j = 0; j < OuterLoopCount; j++)
            {
                maxValue = 0;
                for (int i = 0; i < InnerLoopCount; i++)
                {
                    if (values[i] > maxValue)
                        maxValue = values[i];
                    total += values[i];
                }
            }
            stopwatch.Stop();
            Console.WriteLine("if (a > max) max = a: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < InnerLoopCount; i++)
            {
                //values[i] = i;  // worst case: every new number biggest than the previous
                //values[i] = i == 0 ? 1 : 0;  // best case: first number is the maximum
                values[i] = rnd.Next(int.MaxValue);  // average case: random numbers
            }
            ProfileBase();
            Console.WriteLine();
            ProfileMathMax();
            Console.WriteLine();
            ProfileMathMaxReverse();
            Console.WriteLine();
            ProfileInline();
            Console.WriteLine();
            ProfileIf();
            Console.ReadLine();
        }
      }
    }
