    class Foo { public Bar MyBar { get; } }
    class Bar { public Baz MyBaz { get; } }
    class Baz { }
    
    Baz baz = foo.C(o => o.MyBar).C(o => o.MyBaz) ?? new Baz();
