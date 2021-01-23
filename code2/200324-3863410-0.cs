    class Bar
    {
        public string Name { get; set; }
    }
    class Foo
    {
        public Bar Bar { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo
                          {
                              Bar = new Bar() { Name = "Hello" }
                          };
            Console.WriteLine(foo.Bar.Name);
            Console.ReadLine();
        }
    }
