    public static class Extensions
    {
        public static string Format(this string str, params object[] args)
        {
            return String.Format(str, args);
        }
    }
    
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("string goes here {0} {1}".Format("foo", "bar"));
        }
    }
