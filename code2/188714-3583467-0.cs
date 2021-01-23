    class Program
    {
        static void Main(string[] args)
        {
            int? x = null;
            int? y = 5;
            string s = null;
            string r = "moo";
            Console.WriteLine(ValidateNotNull(x));
            Console.WriteLine(ValidateNotNull(y));
            Console.WriteLine(ValidateNotNull(s));
            Console.WriteLine(ValidateNotNull(r));
            Console.ReadLine();
        }
        private static bool ValidateNotNull(object o)
        {
            return o == null;
        }
    }
