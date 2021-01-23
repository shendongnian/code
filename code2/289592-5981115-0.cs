    interface ISomeInterface
    {
        object Method();
        void Method2();
    }
    interface ISomeInterface<T> : ISomeInterface
    {
        T Method();
    }
    class C1 : ISomeInterface<int>
    {
        public object ISomeInterface.Method() { return Method(); }
        public int Method() { return 10; }
        public void Method2() { }
    }
