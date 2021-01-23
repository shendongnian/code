    class Program
    {
        static void Main(string[] args)
        {
            string x = "Hello World";
            x.DisplayNow();
        }
    }
    public static class StringExtension
    {
        public static void DisplayNow(this string source)
        {
            Console.WriteLine(source);
        }
    }
