    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                Example1();
                Example2();
                Thread.Sleep(500);
                Console.WriteLine("Main");
            }
    
            public static void Example1()
            {
                try
                {
                    Console.WriteLine("Example1");
                    Task t = Task.Run(() => Foo());
                    t.Wait();
                }
                catch (AggregateException e)
                {
                    foreach (var ex in e.InnerExceptions)
                        Console.WriteLine(ex.Message);
                }
            }
    
            public static void Example2()
            {
                try
                {
                    Console.WriteLine("Example2");
                    Task<string> t = Task.Run(() => { Foo(); return "Task result"; });
                    string result = t.Result;
                    Console.Write(result);
                }
                catch (AggregateException e)
                {
                    foreach (var ex in e.InnerExceptions)
                        Console.WriteLine(ex.Message);
                }
            }
    
            public static void Foo()
            {
                throw new Exception("Blahh Exception");
            }
        }
    }
