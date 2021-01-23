    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class MyDisposable : IDisposable
        {
            public void DoSomething()
            {
                Console.WriteLine("  In DoSomething");
            }
    
            #region IDisposable Members
    
            public void Dispose()
            {
                Console.WriteLine("  In Dispose");
            }
    
            #endregion
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting Main\n");
    
                Console.WriteLine("Before NormalMethod");
                NormalMethod();
                Console.WriteLine("After NormalMethod\n");
    
                Console.WriteLine("Before ReturningMethod");
                MyDisposable m = ReturningMethod();
                m.DoSomething(); // Here the object already has been disposed!
                Console.WriteLine("After ReturningMethod\n");
    
            }
    
            private static void NormalMethod()
            {
                using (MyDisposable myDisposable = new MyDisposable())
                {
                    Console.WriteLine("  In NormalMethod");
                }
                return;
            }
    
            private static MyDisposable ReturningMethod()
            {
                using (MyDisposable myDisposable = new MyDisposable())
                {
                    Console.WriteLine("  In ReturningMethod");
                    return myDisposable;
                }
            }
        }
    }
