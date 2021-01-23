    class B
    {
        // Old code here
        public bool RealFoo { get { return status; } }
        // New dummy code
        public virtual bool Foo { get { return RealFoo; } }
    }
