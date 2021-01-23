    public abstract class ImmutableUserType : IUserType
    {
        public new virtual bool Equals(object x, object y)
        {
            return object.Equals(x, y);
        }
        public virtual int GetHashCode(object x)
        {
            return (x == null) ? 0 : x.GetHashCode();
        }
        public override bool IsMutable
        {
            get { return false; }
        }
        public override object DeepCopy(object value)
        {
            return value;
        }
        public override object Replace(object original, object target, object owner)
        {
            return original;
        }
        public override object Assemble(object cached, object owner)
        {
            return cached;
        }
        public override object Disassemble(object value)
        {
            return value;
        }
        public abstract object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner);
        public abstract void NullSafeSet(System.Data.IDbCommand cmd, object value, int index);
        public abstract Type ReturnedType { get; }
        public abstract SqlType[] SqlTypes { get; }
    }
