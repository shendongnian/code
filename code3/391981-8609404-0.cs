    class A {
        private B myB;
        private C myC;
        public A() {
            myC = new C();
            myB = new B(() => myC.MyD);
        }
    }
    class B {
        private readonly Func<D> getD;
        public B(Func<D> getD) {this.getD = getD;}
        public D { get { return getD(); } }
    }
    class C {
        public D MyD {get; private set;}
    }
