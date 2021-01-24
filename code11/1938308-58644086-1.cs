    public class Foo
    {
        public int Bar { get; set; }
    }
    //...
    var foo = new Foo();
    
    //One-liner
    IfNotNull.ThenUpdate(foo, foo => foo.Bar = 2);
