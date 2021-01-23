    public class Base {
        T Foo<T>() : where T : Base { 
            ... // do stuff
            return (T)this; 
        }
    }
    public class A : Base {
        A Bar() { ... }
        A Baz() { ... }
    }
    var x = new A()
        .Bar()
        .Foo<A>() // cast back to A
        .Baz();
