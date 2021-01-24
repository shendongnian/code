    using System;
    namespace ConsoleApp1
    {
        class Finalizable
        {
            ~Finalizable()
            {
                _extendMyLifetime = this;
            }
            public static bool LifetimeExtended => _extendMyLifetime != null;
            static Finalizable _extendMyLifetime;
        }
        class Program
        {
            public static void Main()
            {
                test();
                Console.WriteLine(Finalizable.LifetimeExtended); // False.
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine(Finalizable.LifetimeExtended); // True.
            }
            static void test()
            {
                new Finalizable();
            }
        }
    }
