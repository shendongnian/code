    class Foo { }
    class Bar : Foo { }
    static void Main(string[] args)
    {
        DoSomething(new List<Bar>());
    }
    static void DoSomething(IEnumerable<Foo> lotOfFoos)
    {
        Type t = lotOfFoos.GetType().GetGenericArguments()[0];
        if (t.Name == "Bar")
            Console.WriteLine("works!");
    }
