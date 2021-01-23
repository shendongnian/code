    //Delegate     
    public delegate void OnDoStuff();
        
            class Program
            {
                static void Main(string[] args)
                {
                    //Pass any of the method name here 
                    Invoker(Method1);
                    Console.ReadLine();
                }
        
                private static void Invoker(OnDoStuff method)
                {
                    method.Invoke();
                }
        
                private static void Method1()
                {
                    Console.WriteLine("Method1 from method " + i);
                }
        
                private static void Method2()
                {
                    Console.WriteLine("Method2 from method " + i);
                }
        
                private static void Method3()
                {
                    Console.WriteLine("Method3 from method " + i);
                }
            }
