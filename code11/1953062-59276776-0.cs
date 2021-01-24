    class Foo { public void M() { }}
    class Bar { public void M() { }}
    ...
    object o = X() ? (object) new Foo() : (object) new Bar();
    o.M(); // Illegal.
    dynamic d = o;
    d.M(); // Legal; calls either Foo.M or Bar.M
