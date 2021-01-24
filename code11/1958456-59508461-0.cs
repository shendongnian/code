    public class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
    
            Console.WriteLine("Program ran.");
            Console.ReadKey();
        }
    
        public void Run()
        {
    	    // call a private method
            Method1();
    	
    	    // call a private method with param
    	    Method2("some string");
        }
    
        private void Method1()
        {
            // do some stuff
        }
        
        private void Method2(string s)
        {
            // do some stuff
            Console.WriteLine(s);
        }
    }
