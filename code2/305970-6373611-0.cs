    using System;
    using System.Diagnostics;
    
    namespace TestVariableScopePerformance
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestClass tc = new TestClass();
                Stopwatch sw = new Stopwatch();
    
                sw.Start();
                tc.MethodGlobal();
                sw.Stop();
    
                Console.WriteLine("Elapsed for MethodGlobal = {0} Minutes {1} Seconds {2} MilliSeconds", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
                sw.Reset();
    
                sw.Start();
                tc.MethodLocal();
                sw.Stop();
    
                Console.WriteLine("Elapsed for MethodLocal = {0} Minutes {1} Seconds {2} MilliSeconds", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
    
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
    
            
        }
    
        class TestClass
        {
            const int Const1 = 100;
            
            internal void MethodGlobal()
            {
                double temp = 0d;
                for (int i = 0; i < int.MaxValue; i++)
                {
                    temp = (i * Const1);
                }
            }
    
            internal void MethodLocal()
            {
                const int Const2 = 100;
                double temp = 0d;
                for (int i = 0; i < int.MaxValue; i++)
                {
                    temp = (i * Const2);
                }
            }
        }
    }
