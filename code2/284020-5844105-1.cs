    public static bool ContainsField<T>(this IEnumerable<T> array,
        string fieldname, object obj)
    {
        var param = Expression.Parameter(typeof(T));
        var member = Expression.PropertyOrField(param, fieldname);
        var body = Expression.Equal(member, Expression.Constant(obj, member.Type));
        var lambda = Expression.Lambda<Func<T,bool>>(body, param);
        return array.Any(lambda.Compile());
    }
