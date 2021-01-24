    public static int CheckDuplicate<T>(IEnumerable<T> input, string field, object value)
    {
        int count = 0;
        Type type = typeof(T);
        foreach(var item in input)
        {
            var fieldInfo = type.GetField(field);
            if(fieldInfo!= null)
                if(fieldInfo.GetValue(item) == value) count++;
            else
            {
                var propInfo = type.GetProperty(field);
                if(propInfo != null && propInfo.GetValue(item) == value) count++;
            }
        }
        return count;
    }
