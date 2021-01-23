    // Assembly P1
    public class C1
    {
        ...
    }
    
    // Assembly P2
    public class C2
    {
        public string Foo { get; set; }
        public C1 Bar { get; set; }
    }
    
    // Assembly P3
    void Main()
    {
        C2 c = ...
        Console.WriteLine(c.Foo);
    }
