    public class Foo {
        public string PropOne { get; set; }
        public string PropTwo { get; set; }
        public Foo(string propOne, string propTwo) {
            PropOne = propOne;
            PropTwo = propTwo;
        }
        public Foo(Foo foo) {
            PropOne = foo.PropOne;
            PropTwo = foo.PropTwo;
        }
    }
    public class Pho : Foo {
        // if you have additional properties then handle them here
        // and let the base class take care of the rest.
        public string PropThree { get; set; }
        public Pho(string propOne, string propTwo, string propThree) 
            : base(propOne, propTwo) {
            PropThree = propThree; 
        }
        public Pho(Pho pho) : base(pho) {
            PropThree = pho.PropThree;
        }
        // otherwise you can just rely on a copy constructor
        // to handle the initialization.
        public Pho(Foo foo) : base(foo) {}
    }
