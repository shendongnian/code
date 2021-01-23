    // This is not allowed
    class A { void A() {} }
    class B { void B() {} }
    class C : A, B {}
    // This is allowed
    interface IA { void A(); }
    interface IB { void B(); }
    class A : IA, IB
    {
        public void A() {}
        public void B() {}
    }
