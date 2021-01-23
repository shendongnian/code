    public class Base {
        T Foo<T>() : where T : Base { 
            ... // do stuff
            return (T)this; 
        }
    }
    public class A : Base {
        A Bar() { ...; return this; }
        A Baz() { ...; return this; }
    }
    var x = new A()
        .Bar()
        .Foo<A>() // cast back to A
        .Baz();
