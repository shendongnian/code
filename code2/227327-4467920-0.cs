    // declared somewhere
    struct Foo {
        public int x;
        public int y;
    }
    struct Bar {
        public int x;
        public int y;
    }
    // ... in a method body
    Foo item = new Foo { x = 1, y = 2 };
    Bar b1 = item; // doesn't compile, and casting doesn't compile
    Bar b2 = new Bar { x = 1, y = 2 }; // compiles!
