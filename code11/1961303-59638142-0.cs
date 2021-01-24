    class A
    {
        protected readonly B _b;
        public A()
        {
            _b = new B(this);
        }
    }
    class B
    {
        protected readonly A _a;
        public B(A a)
        {
            _a = a;
        }
        public A GetCreator()
        {
            return _a;
        }
    }
