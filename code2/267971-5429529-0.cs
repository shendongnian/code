    class Bar { public int I; }
    struct Foo { public Bar B; }
    var b = new Bar();
    var f = new Foo { B = b; }
    dict[key] = f;
    b.I++;
