    public static TResult GetPropertyValue<TType, TResult>(this TType t, string propertyName)
    {
        object val = t.GetType().GetProperties().Single(pi => pi.Name == propertyName).GetValue(t, null);
        return (TResult)val;
    }
