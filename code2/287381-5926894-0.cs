    class Poolable
    {
        public virtual void Free() { }
        public virtual void OnFree() { }  // naming not according to BCL std
    }
    
    class Light : Poolable
    {
        public override void Free() { }
        ...
    }
