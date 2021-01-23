    abstract class A {
        public int Value {get; protected set;}
    }
    class R : A { }
    class W : A {
        new public int Value {
            get { return base.Value; }
            set { base.Value = value; }
        }
    }
