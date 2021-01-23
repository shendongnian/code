    //Delegate     
    public delegate void OnDoStuff(string name);
        
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
                    method.Invoke("Whatever");
                }
        
                private static void Method1(string i)
                {
                    Console.WriteLine("Method1 from method " + i);
                }
        
                private static void Method2(string i)
                {
                    Console.WriteLine("Method2 from method " + i);
                }
        
                private static void Method3(string i)
                {
                    Console.WriteLine("Method3 from method " + i);
                }
            }
