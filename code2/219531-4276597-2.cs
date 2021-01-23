    static void Main()
    {        
        var data = new[] {
           new { Foo = 123, Bar = "abc" },
           new { Foo = 456, Bar = "def" },
           new { Foo = 789, Bar = "ghi" },
        };
        string s = Write(data);        
    }
    static Expression StringBuilderAppend(Expression instance, Expression arg)
    {
        var method = typeof(StringBuilder).GetMethod("Append", new Type[] { arg.Type });
        return Expression.Call(instance, method, arg);
    }
    static string Write<T>(IEnumerable<T> data)
    {
        var props = typeof(T).GetProperties();
        var sb = Expression.Parameter(typeof(StringBuilder));
        var obj = Expression.Parameter(typeof(T));
        Expression body = sb;
        foreach(var prop in props) {            
            body = StringBuilderAppend(body, Expression.Property(obj, prop));
            body = StringBuilderAppend(body, Expression.Constant("="));
            body = StringBuilderAppend(body, Expression.Constant(prop.Name));
            body = StringBuilderAppend(body, Expression.Constant("; "));
        }
        body = Expression.Call(body, "AppendLine", Type.EmptyTypes);
        var lambda = Expression.Lambda<Func<StringBuilder, T, StringBuilder>>(body, sb, obj);
        var func = lambda.Compile();
        var result = new StringBuilder();
        foreach (T row in data)
        {
            func(result, row);
        }
        return result.ToString();
    }
