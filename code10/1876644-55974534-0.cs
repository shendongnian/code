    using System;
    
    namespace ConsoleApp12
    {
        class A
        {
            public int P1 { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                A myvariable = new A
                {
                    P1 = 1,
                };
    
                object obj = myvariable;
                string typename = "ConsoleApp12.A";
    
                Type type = Type.GetType(typename);
    
                dynamic origMsg = (dynamic)Convert.ChangeType(obj, type);
    
                Console.WriteLine(origMsg.P1);
                Console.ReadKey();
            }
        }
    }
