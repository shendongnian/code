    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => MyMethod("param value"));
        }
        private static void MyMethod(string p)
        {
            Console.WriteLine(p);
        }
    }
