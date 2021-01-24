    public static int CheckDuplicate<T>(IEnumerable<T> input, string field, object value)
    {
        int count = 0;
        Type type = typeof(T);
        foreach(var item in input)
        {
            var fieldInfo = type.GetField(field);
            if(fieldInfo.GetValue(item) == value) count++;
        }
        return count;
    }
