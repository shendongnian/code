    class Program
    {
        static void Main(string[] args)
        {
            // tests
            Func<string> stringFunc = () => 
                "hello!";
            
            Func<List<Foo>> listFooFunc = () => 
                new List<Foo> 
                { 
                    new Foo("Hello!"),
                    new Foo("World!")
                };
            Func<IEnumerable> ienumerableFooFunc = () =>
                new Hashtable
                {
                    { "ItemOne", "Foo" },
                    { "ItemTwo", "Bar" }
                };
       
            var fooBarOfT = new FooBarOfT();
            fooBarOfT.FooBar(stringFunc);
            fooBarOfT.FooBar(listFooFunc);
            fooBarOfT.FooBar(ienumerableFooFunc);
            Console.ReadKey();
        }
    }
 
    
