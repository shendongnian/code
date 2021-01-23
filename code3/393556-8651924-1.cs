    class Program
            {
            private static readonly TraceSource ActiveTraceSource = new TraceSource("Test"); 
            static void Main(string[] args)
                {
                
                ActiveTraceSource.TraceInformation("Hi");
                Thread th = new Thread(new ThreadStart(Test));
                th.Start();
                Console.ReadLine();
                }
    
            static void Test()
                {
                ActiveTraceSource.TraceInformation("Hi");
                }
            }
