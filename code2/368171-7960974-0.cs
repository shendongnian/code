    namespace TestNamespace
    {
        using System;
        public class Test
        {
            public static void Main()
            {
                var foo = new Bar();
                Console.ReadKey();
            }
        }
        class Foo
        {
            public Foo(Type type) { Console.WriteLine("The type of Foo is: " + type.ToString()); }
        }
        class Bar : Foo
        {
            public Bar() : base(typeof(Bar)) { }
        }
    }
