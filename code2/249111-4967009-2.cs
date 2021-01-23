    using System;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var example = new Example())
                {
                    //do something
                }
            }
        }
    
        class Example : IDisposable
        {
    
            public void Dispose()
            {
                //Do something
            }
        }
    }
