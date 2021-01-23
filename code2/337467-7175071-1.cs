    class Foo { public int x; }
    class Bar { public readonly Foo y = new Foo(); }
    Bar a = new Bar();
    a.y.x = 3; // valid
    a.y = new Foo(); // invalid
