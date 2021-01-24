    class BaseClass
    {
        public int Answer { get; protected set; }
        protected virtual void VM1() { Answer += 20; }
        protected virtual void VM2() { Answer += 10; }
        public void Init() { VM1(); VM2(); }
    }
    class DerivedClass : BaseClass
    {
        private int _dividend;
        protected override void VM1() { Answer = _dividend = 20; }
        protected override void VM2() { Answer /= 10 }
    }
