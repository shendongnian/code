    namespace ConsoleApplication1
    {
        public class Foo
        {
            public Foo(int optional = 42)
            {
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Activator.CreateInstance<Foo>(); // causes MissingMethodException
            }
        }
    }
