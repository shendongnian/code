    class Program
    {
        static void Foo(ref StringBuilder x)
        {
            x = null;
        }
        static void Main(string[] args)
        {
            StringBuilder y = new StringBuilder();
            y.Append("hello");
            Foo(ref y);
            Console.WriteLine(y == null); //Prints "true".
        }
    }
