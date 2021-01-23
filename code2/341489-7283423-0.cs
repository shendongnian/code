    class Foo 
    { 
         public string SomeProperty { get; private set; }
         public Foo(string bar) { SomeProperty = bar } 
    }
    Foo someOtherFoo = new Foo("B");
    Foo foo = someOtherFoo;
    someOtherFoo = new Foo("C");
