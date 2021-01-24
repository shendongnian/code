    // because you said in comments that all fields are string I'm using Func<T, string> here
    public static Expression<Func<T, string>> Create<T>(string fieldName)
    {
        var parameter = Expression.Parameter(typeof(T), "p");
        var property = Expression.PropertyOrField(parameter, fieldName);
        return Expression.Lambda<Func<T, string>>(property, parameter);
    }
