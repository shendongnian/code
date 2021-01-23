    class Foo {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    
    Func<Foo, object> lambda = foo => new { foo.Property1, foo.Property 2 };
    
    var foo = new Foo { Property1 = "foo", Property2 = "bar" };
    var anon = lambda(foo);
