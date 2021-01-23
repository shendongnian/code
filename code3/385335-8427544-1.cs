    public static class Extensions
    {
        public static void Foo(this object o, dynamic x)
        {
        }
    }
    
    class Program
    {
        static void Main()
        {
            dynamic x = "abc";
            new object().Foo(x); // Compile time error here
        }
    }
