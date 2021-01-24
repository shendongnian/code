    public abstract class Calculate
    {
        public abstract int input { get; set; }
        public virtual int  foo() { return input * 2; }
    }
