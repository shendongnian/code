    public static string ReadPrivateField<T>(T obj, string fieldName)
    {
        var type = typeof(T);
        var field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        var value = field.GetValue(obj);
        return value as string;
    }
