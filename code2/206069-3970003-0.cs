    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Taking data from Main Thread\n->");
            string message = Console.ReadLine();  
    
            Thread myThread = new Thread(Write);
            myThread.Start(message);
    
        }
    
        public static void Write(object obj)
        {
            string msg = (string)obj;
            Console.WriteLine(msg);
            Console.Read();
        }
    }
