    struct Foo
    {
        public int[] parts;
    }
    void Main()
    {
        Foo f1 = new Foo() { parts = new int[] {3, 6, 9}};
        Foo f2 = new Foo() { parts = new int[] {4, 40, 400, 4000}};
        Foo f3 = new Foo() { parts = new int[] {3, 33, 333}};
        var fooList = new List<Foo>() { f2, f3 };
    
        foreach (var element in tellFoo(f1))
            Console.WriteLine(element);
    
        foreach (var element in tellFoo(fooList))
            Console.WriteLine(element);
    }
    IEnumerable<int> tellFoo(Foo x)
    {
        foreach (var element in x.parts)
            yield return element;
    }
    IEnumerable<int> tellFoo(IEnumerable<Foo> foos)
    {
        foreach (var foo in foos)
            foreach (var element in tellFoo(foo))
                yield return element;
    }
