    private class SubClass<T>: BaseClass
    {
        public new T Value
        {
            get => (T) base.Value;
            set => base.Value = value;
        }
        //Added this here in the generic subclass
        public virtual bool ShouldSerializeValue() => true;
    }
