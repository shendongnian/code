    class Program
    {
        public static void Main(string[] args)
        {
    #if DEBUG
            Console.WriteLine("test");
    #else
            Application.Run(new Form1());
    #endif
        }
    }
