    public static bool ContainsField<T>(this IEnumerable<T> array,
                                        string fieldname,
                                        object obj)
    {
        Field field = typeof(T).GetField(fieldName);
        return array.Any(x => field.GetValue(x).Equals(obj));
    }
