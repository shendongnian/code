    public class A { public Guid ID { get; set; } }
    public class B { public A Parent { get; set; } }
    
    A someA = new A();
    B someB = new B();
    someB.Parent = someA;
