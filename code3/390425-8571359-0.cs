    // bad design
    public class Foo {
       public Foo(string name, int? id);
    }
    // good design
    public class Foo {
       public Foo(string name, int id);
       public Foo(string name);
    }
