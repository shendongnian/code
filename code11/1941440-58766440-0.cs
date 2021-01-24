    public class B {
        private A myA { get; public set; }
        public B() {}
        public B(A a) {
            myA = a;
            a.B = this;
        }
    }
    public class A {
        private B myB { get; public set; }
        public A(){}
        public A(B b) {
            myB = b;
            b.A = this;
        }
    }
    var a = new A(new B());
