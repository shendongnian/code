    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    namespace TestMathMax {
        class Program {
            static int Main(string[] args) {
                var num1 = 10;
                var num2 = 100;
                var maxValue = 0;
                var LoopCount = 1000000000;
                double controlTotalSeconds;
                { 
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (var i = 0; i < LoopCount; i++) {
                        // do nothing
                    }
                    stopwatch.Stop();
                    controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
                    Console.WriteLine("Control - Empty Loop - " + controlTotalSeconds + " seconds");
                }
                Console.WriteLine();
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < LoopCount; i++) {
                        maxValue = Math.Max(num1, num2);
                    }
                    stopwatch.Stop();
                    Console.WriteLine("Math.Max() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
                    Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");
                }
                Console.WriteLine();
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < LoopCount; i++) {
                        maxValue = num1 > num2 ? num1 : num2;
                    }
                    stopwatch.Stop();
                    Console.WriteLine("Inline Max: " + stopwatch.Elapsed.TotalSeconds + " seconds");
                    Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");
                }
                Console.ReadLine();
                return maxValue;
            }
        }
    }
