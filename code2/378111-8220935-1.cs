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
    public static class NullableHelper
    {
        public static object GetNullableValue(this FieldInfo field, object target)
        {
            return NullableObject.GetField(target, field);
        }
    }
