    using System;
    using System.Diagnostics;
    namespace test
    {
        class MainApp
        {
            static void Main()
            {
                Foo f = new Foo();
                IFoo f2 = f;
                // JIT warm-up
                f.Bar();
                f2.Bar();
                int N = 10000000;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < N; i++)
                {
                    f2.Bar();
                }
                sw.Stop();
                Console.WriteLine("Through interface: {0:F2}", sw.Elapsed.TotalMilliseconds);
                sw.Reset();
                sw.Start();
                for (int i = 0; i < N; i++)
                {
                    f.Bar();
                }
                sw.Stop();
                Console.WriteLine("Direct call: {0:F2}", sw.Elapsed.TotalMilliseconds);
                Console.Read();
            }
            interface IFoo
            {
                void Bar();
            }
            class Foo : IFoo
            {
                public virtual void Bar()
                {
                }
            }
        }
    }
