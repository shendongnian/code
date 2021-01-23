    public abstract class SomeClass : ISomePublicProperties, ISomeInternalProperties 
    {
        public abstract int PropertyOne { get; }
        internal abstract int PropertyTwo { get; }
    }
