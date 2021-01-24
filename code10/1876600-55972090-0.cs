     class Program
    {
        string hello = "Hello, World!";
        static void Main(string[] args)
        {
            var test = new Program();
            test.OtherMethod();
        }
        void OtherMethod()
        {
            Console.WriteLine(hello);
        }
    }
