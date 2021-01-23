    public abstract class SomeClass : ISomePublicProperties, ISomeInternalProperties 
    {
        public virtual int PropertyOne { get; }
        internal virtual int PropertyTwo { get; }
    }
