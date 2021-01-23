    public static class Program
    {
        // you can define your own delegate for a nice meaningful name, but the
        // generic delegates (Func, Action, Predicate) are all defined already
        public delegate string ConvertedMethod(string value);
        public static void Main()
        {
            // both work fine for taking methods, lambdas, etc.
            Func<string, string> convertedMethod = s => s + ", Hello!";
            ConvertedMethod convertedMethod2 = s => s + ", Hello!";
        }
    }
