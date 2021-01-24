    public sealed class EmployeeNumberUserType : SingleValueObjectType<EmployeeNumber>
    {
        protected override NullableType PrimitiveType => NHibernateUtil.Int32;
    }
    public abstract class SingleValueObjectType<TValueObject> : IUserType where TValueObject : class
    {
        public SqlType[] SqlTypes => new[] { PrimitiveType.SqlType };
        public Type ReturnedType => typeof(TValueObject);
        public bool IsMutable => false;
        public object Assemble(object cached, object owner) => cached;
        public object DeepCopy(object value) => value;
        public object Disassemble(object value) => value;
        public new bool Equals(object x, object y) => x?.Equals(y) ?? y?.Equals(x) ?? true;
        public int GetHashCode(object x) => x?.GetHashCode() ?? 0;
        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var obj = PrimitiveType.NullSafeGet(rs, names[0], session, owner);
            if (obj == null) return null;
            else return Activator.CreateInstance(typeof(TValueObject), obj);
        }
        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            if (value == null) cmd.Parameters[index].Value = DBNull.Value;
            else cmd.Parameters[index].Value = value.GetType()
                                                    .GetProperty("Value", BindingFlags.Instance | BindingFlags.NonPublic)
                                                    .GetValue(value);
        }
        public object Replace(object original, object target, object owner) => original;
        protected abstract NullableType PrimitiveType { get; }
    }
