    class A1<U> 
    {
        public virtual void Generic<T>(T t, U u) { }
    }
    class A2 : A1<int>
    {
        public override void Generic<T>(T t, int u) { } // no error
    }
