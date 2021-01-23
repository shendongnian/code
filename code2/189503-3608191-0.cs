    public static class ObjectExtensions
    {
        private static Dictionary<Type, ConstructorInfo> _NullableEnumCtor = new Dictionary<Type, ConstructorInfo>();
        public static T As<T>(this object pObject)
        {
            return As(pObject, default(T));
        }
        public static T As<T>(this object pObject, T pDefaultValue)
        {
            if (pObject == null || pObject == DBNull.Value)
                return pDefaultValue;
            var lObjectType = pObject.GetType();
            var lTargetType = typeof(T);
            if (lObjectType == lTargetType)
                return (T) pObject;
            var lCtor = GetNullableEnumCtor(lTargetType);
            if (lCtor == null)
                return (T) pObject;
            return (T)lCtor.Invoke(new[] { pObject });
        }
        private static ConstructorInfo GetNullableEnumCtor(Type pType)
        {
            if (_NullableEnumCtor.ContainsKey(pType))
                return _NullableEnumCtor[pType];
            var lUnderlyingType = Nullable.GetUnderlyingType(pType);
            if (lUnderlyingType == null || !lUnderlyingType.IsEnum)
            {
                lock (_NullableEnumCtor) { _NullableEnumCtor.Add(pType, null); }
                return null;
            }
            var lNullableType = typeof(Nullable<>).MakeGenericType(lUnderlyingType);
            var lCtor = lNullableType.GetConstructor(new[] { lUnderlyingType });
            lock (_NullableEnumCtor) { _NullableEnumCtor.Add(pType, lCtor); }
            return lCtor;
        }
    }
