    class Program
    {
        [DllImport("TestDLL.dll")]
        public static extern int Add(int a, int b);
    
        static void Main()
        {
            Console.WriteLine(Add(1, 2));
        }
    }
