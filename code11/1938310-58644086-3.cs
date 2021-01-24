    public class Foo
    {
        public int Bar { get; set; }
    }
    //...
    var foo = new Foo();
    
    //One-liner
    foo.UpdateIfNotNull(f => f.Bar = 2);
