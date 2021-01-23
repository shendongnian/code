    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace Stackoverflow_Test
    {
        class TestToArrayVsEnumerator
        {
            private const string numString = "1,2,3,4,5,6,7";
            private readonly string[] numArray;
            private const int iterations = 100000;
            private const int numTests = 10;
            public TestToArrayVsEnumerator()
            {
                numArray = numString.Split(',');
            }
            public void Run()
            {
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                Console.WriteLine("Warmup");
                RunTest(WithEnumerator);
                RunTest(WithSelectFirst);
                RunTest(WithSelectToArray);
                RunTest(StraightForward);
                Console.WriteLine("--- test start ---");
                StringBuilder sb = new StringBuilder();
                foreach (var t in Enumerable.Range(0, numTests))
                {
                    var timeEnumerator = RunTest(WithEnumerator);
                    var timeWithSelectFirst = RunTest(WithSelectFirst);
                    var timeWithSelectToArray = RunTest(WithSelectToArray);
                    var timeStraightForward = RunTest(StraightForward);
                    sb.AppendLine("WithEnumerator, " + timeEnumerator.TotalMilliseconds + " ms. "
                        + "WithSelectFirst, " + timeWithSelectFirst.TotalMilliseconds + " ms. (" + ((100 * ((double)timeWithSelectFirst.Ticks / (double)timeEnumerator.Ticks)) - 100) + "%) "
                        + "WithSelectToArray, " + timeWithSelectToArray.TotalMilliseconds + " ms. (" + ((100 * ((double)timeWithSelectToArray.Ticks / (double)timeEnumerator.Ticks)) - 100) + "%) "
                        + "StraightForward, " + timeStraightForward.TotalMilliseconds + " ms. (" + ((100 * ((double)timeStraightForward.Ticks / (double)timeEnumerator.Ticks)) - 100) + "%) "
                        );
                }
                Console.WriteLine(sb.ToString());
                MessageBox.Show(sb.ToString());
                Console.WriteLine("--- test end ---");
            }
            private TimeSpan RunTest(Action test)
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                foreach (var i in Enumerable.Range(0, iterations))
                {
                    test();
                }
                sw.Stop();
                return sw.Elapsed;
            }
            public void WithEnumerator()
            {
                var array1 = numArray.Take(5).Select(s => int.Parse(s)).ToArray();
                var array2 = numArray.Skip(5).Select(s => int.Parse(s)).ToArray();
            }
            public void WithSelectFirst()
            {
                var intArray = numArray.Select(s => int.Parse(s)).ToArray();
                var array1 = numArray.Take(5).ToArray();
                var array2 = numArray.Skip(5).ToArray();
            }
            public void WithSelectToArray()
            {
                var intArray = numArray.Select(s => int.Parse(s)).ToArray();
                var array1 = numArray.Take(5).ToArray();
                var array2 = numArray.Skip(5).ToArray();
            }
            public void StraightForward()
            {
                var array1 = new int[5];
                var array2 = new int[2];
                array1[0] = int.Parse(numArray[0]);
                array1[1] = int.Parse(numArray[1]);
                array1[2] = int.Parse(numArray[2]);
                array1[3] = int.Parse(numArray[3]);
                array1[4] = int.Parse(numArray[4]);
                array2[0] = int.Parse(numArray[5]);
                array2[1] = int.Parse(numArray[6]);
            }
        }
    }
