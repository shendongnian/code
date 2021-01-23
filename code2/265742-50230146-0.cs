    public abstract class TypedGuid
    {
        protected TypedGuid(Guid value)
        {
            Value = value;
        }
        public Guid Value { get; }
    }
