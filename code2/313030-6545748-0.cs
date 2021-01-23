    static class ExtendedString
    {
        public static String TestMethod(this String str, String someParam)
        {
            return someParam;
        }
    }
    
    static void Main(string[] args)
    {
        String str = String.Empty;
        Console.WriteLine(str.TestMethod("Hello World!!"));
        ........
    }
