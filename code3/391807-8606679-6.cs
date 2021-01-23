    class B<T> 
    {
        public virtual void M<U>() where U : T {}
    }
    class D<V> : B<IEnumerable<V>>
    {
        public override void M<U>() {}
    }
