    class Program
    {
        static Program programObject = new Program();
        static void Main(string[] args)
        {
            Program po = new Program();
            po.testing();
            Console.ReadLine();
        }
        void testing()
        {
            Console.WriteLine("Testing is working fine!!!");
        }
    }
