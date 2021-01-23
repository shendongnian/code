    class Program
    {
        public static void Main()
        {
            string s = null;
            string s2 = "Hi";
            Console.WriteLine(s2 ?? s.ToString());
        }
    }
