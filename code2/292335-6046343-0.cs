    public class Foo
    {
        public Foo Bar { get; set; }
    }
    ...
    static void Main()
    {
        Foo f1 = new Foo();
        Foo f2 = new Foo();
        f1.Bar = f2;
        f2.Bar = f1;
        // Not actually required so long as nothing in the rest of the method
        // references f1 and f2
        f1 = null;
        f2 = null;
        // The two Foo objects refer to each other, but they're both eligible for
        // garbage collection.
    }
