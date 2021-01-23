    public static class ConvertTo<T>
    {
        // 'Factory method delegate', set in the static constructor
        public static readonly Func<object, T> From;
        static ConvertTo()
        {
            From = Create(typeof(T));
        }
        private static Func<object, T> Create(Type type)
        {
            if (!type.IsValueType)
            {
                return ConvertRefType;
            }
            if (type.IsNullableType())
            {
                return (Func<object, T>)Delegate.CreateDelegate(
                    typeof(Func<object, T>),
                    typeof(ConvertTo<T>).GetMethod("ConvertNullableValueType", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(new[] { type.GetGenericArguments()[0] }));
            }
            return ConvertValueType;
        }
        // ReSharper disable UnusedMember.Local
        // (used via reflection!)
        private static TElem? ConvertNullableValueType<TElem>(object value) where TElem : struct
        {
            if (DBNull.Value == value)
            {
                return null;
            }
            return (TElem)value;
        }
        // ReSharper restore UnusedMember.Local
        private static T ConvertRefType(object value)
        {
            if (DBNull.Value != value)
            {
                return (T)value;
            }
            return default(T);
        }
        private static T ConvertValueType(object value)
        {
            if (DBNull.Value == value)
            {
                throw new NullReferenceException("Value is DbNull");
            }
            return (T)value;
        }
    }
