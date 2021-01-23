    public static TOutput GetPropertyByCodeName<TOutput>(this object obj, string codeName)
    {
        var property = obj.GetType()
                          .GetProperties()
                          .Where(p => p.IsDefined(typeof(CodeNameAttribute), false))
                          .Single(p => ((CodeNameAttribute)(p.GetCustomAttributes(typeof(CodeNameAttribute), false).First())).Name == codeName);
    
        return (TOutput)property.GetValue(obj, null);
    }
