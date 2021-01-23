    public class Foo<T>
    {
        public Foo(T value) { }
    }
    public class Foo
    {
        public Foo(int value) { }
    }
    //...
    var x = new Foo(5); // which one?
