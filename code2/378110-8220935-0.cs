    struct NullableObject
    {
        public object Value { get; private set; }
        public static object GetField(object Target, FieldInfo Field)
        {
            object value = Field.GetValue(Target);
            if (Nullable.GetUnderlyingType(Field.FieldType) != null)
                return new NullableObject { Value = value };
            return value;
        }
    }
