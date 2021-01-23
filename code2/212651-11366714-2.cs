    interface IFunClass {
        void Fun();
    }
    class A : IFunClass {
        public void IFunClass.Fun() {
            Console.Write("Class A!");
        }
    }
    class B : IFunClass {
        public B(IFunClass f) {
            this.m_SomethingFun = f;
        }
        public void IFunClass.Fun() {
            this.m_SomethingFun.Fun();
            Console.Write("Class B!");
        }
        private IFunClass m_SomethingFun;
    }
    A a = new A();
    B b = new B(a);
    b.Fun() // will call a.Fun() first inside b.Fun()
