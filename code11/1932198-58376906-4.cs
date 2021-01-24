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
                new Finalizable();
                
                Console.WriteLine(Finalizable.LifetimeExtended); // False.
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine(Finalizable.LifetimeExtended); // True iff RELEASE build.
            }
        }
    }
