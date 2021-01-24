    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
            var bar = new Bar();
            Console.Write(foo.ClassName());
            Console.Write(bar.ClassName());
            Console.ReadKey();
        }
    }
    class Foo
    {
        public string ClassName()
        {
            return GetType().Name;
        }
    }
    class Bar : Foo
    {
    }
