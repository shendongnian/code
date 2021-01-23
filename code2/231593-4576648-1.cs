    class Foo
    {
        public int Bar { get; set; }
    }
    class FooComparer : IComparer<Foo>
    {
        public int Compare(Foo x, Foo y)
        {
            // add null checking, demo purposes only
            return x.Bar.CompareTo(y.Bar);
        }
    }
...
    SortedSet<Foo> sortedFoos = new SortedSet<Foo>(new FooComparer());
    sortedFoos.Add(new Foo() { Bar = 2 });
    sortedFoos.Add(new Foo() { Bar = 1 });
    foreach (Foo foo in sortedFoos)
    {
        Console.WriteLine(foo.Bar);
    }
    // Prints 1, 2
