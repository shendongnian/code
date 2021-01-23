    public static TResult GetPropertyValue<TResult>(this object t, string propertyName)
    {
        object val = t.GetType().GetProperties().Single(pi => pi.Name == propertyName).GetValue(t, null);
        return (TResult)val;
    }
