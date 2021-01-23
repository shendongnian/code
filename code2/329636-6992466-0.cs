    class Myclass
    {     
    static Myclass() 
        static void Main(string[] args)
        {
            Console.WriteLine("1st");
            Process(args);
            Console.WriteLine("3rd");
        }  
        static void Process(string[] args) {
            Console.WriteLine("2nd"); // it will print 2nd
        }
    }
