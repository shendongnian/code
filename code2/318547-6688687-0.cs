    using ConsoleApplication3;
    class Program
    {
        static void Main(string[] args)
        {
            ThirdPartyClass t = new ThirdPartyClass();
            Console.WriteLine(t.Fun("hh"));
            Console.WriteLine(t.Fun(1));
        }
    }
    public static class LocalExtension
    {
        public static string Fun(this ThirdPartyClass test, int val)
        {
            return "Local" + val;
        }
        public static string Fun(this ThirdPartyClass test, string val)
        {
            return "Local" + val;
        }
    }
