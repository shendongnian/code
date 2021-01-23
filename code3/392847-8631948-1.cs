    class A {
        public A(A copyMe) {
            s1 = copyMe.s1;
            ...
        }
    class B : A {
        public B(A aInstance) : base(aInstance) {
        }
    }
