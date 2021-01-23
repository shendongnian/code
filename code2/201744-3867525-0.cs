    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            var test1 = new float[100000000];  // 100 million
            for (int ix = 0; ix < test1.Length; ++ix) test1[ix] = ix;
            var test2 = new Test[test1.Length / 2];
            for (int ix = 0; ix < test2.Length; ++ix) test2[ix].x = test2[ix].y = ix;
            for (int cnt = 0; cnt < 20; ++cnt) {
                var sw1 = Stopwatch.StartNew();
                bool dummy = false;
                for (int ix = 0; ix < test1.Length; ix += 2) {
                    dummy ^= test1[ix] >= test1[ix + 1];
                }
                sw1.Stop();
                var sw2 = Stopwatch.StartNew();
                for (int ix = 0; ix < test2.Length; ++ix) {
                    dummy ^= test2[ix].x >= test2[ix].y;
                }
                sw2.Stop();
                Console.Write("", dummy);
                Console.WriteLine("{0} {1}", sw1.ElapsedMilliseconds, sw2.ElapsedMilliseconds);
            }
            Console.ReadLine();
        }
        struct Test {
            public float x;
            public float y;
        }
    }
