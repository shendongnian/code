    class Program
    {
        [DllImport("yourlibrary.dll")]
        public static extern int YourMethod(int parameter);
        static void Main(string[] args)
        {
            Console.WriteLine(YourMethod(42));
        }
    }
