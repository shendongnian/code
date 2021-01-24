    class Program
    {
        static void Main(string[] args)
        {
            string str = "01/08/2019";
            string normalizedStr = Normalize(str);
        }
        private static string Normalize(string str)
        {
            return string.Join("-", str.Split(new char[] { '/' }).Reverse());
        }
    }
