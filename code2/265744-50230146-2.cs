    public abstract class TypedGuid
    {
        protected TypedGuid(Guid value)
        {
            Value = value;
        }
        public bool HasValue => !Value.Equals(Guid.Empty);
        public Guid Value { get; }
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
    }
