    class Foo
    {
        public static explicit operator Bar(Foo foo)
        {
            Bar bar = new Bar();
            bar.Name = foo.Name;
            return bar;
        }
        public string Name { get; set; }
    }
    class Bar
    {
        public static implicit operator Foo(Bar bar)
        {
            Foo foo = new Foo();
            foo.Name = bar.Name;
            return foo;
        }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Bar bar = (Bar)(new Foo() { Name = "Blah" }); // explicit cast and conversion
            Foo foo = bar; // implicit cast and conversion
        }
    }
