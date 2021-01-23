    class Foo : INamed {
        private readonly string name;
        private readonly int foo;
        public string Name { get { return this.name; } } 
        public Foo(string name, int foo) {
            this.name = name; 
            this.foo = foo;
        }
    }
    MyList<Foo> list = // some instance of MyList<Foo>
    Foo alice = list.Get("Alice");
        
