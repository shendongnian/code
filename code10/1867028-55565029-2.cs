    public class Foo
    {    
       public Foo() { }
       
    #if DEBUG
       internal Foo2(Something something) { }
    #endif
    }
