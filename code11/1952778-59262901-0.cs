 c#
    private void WriteReport<T>(List<T> rows, Func<T, string>[] columns, string dest)
    {
        using (var writer = new System.IO.StreamWriter(dest))
        {
            foreach (T row in rows)
            {
                foreach (var m in columns)
                {
                    writer.Write(m(row));
                }
                writer.WriteLine();
                writer.Flush();
            }
            writer.Close();
        }
    }
Then you can just use lambdas at the call site, i.e.
 c#
List<Foo> foos = ...
yourObject.writeReport(foos, new[] { x => x.SomeMethod(), x => x.AnotherMethod() }, path);
---
However, if that isn't possible, then: something like the following should work nicely:
 c#
    static readonly ParameterExpression s_sharedParam = Expression.Parameter(
        typeof(object), "obj");
    static readonly ParameterExpression[] s_sharedParams = new[] { s_sharedParam };
    static Func<object,object> AsFuncObjectObject(MethodInfo method)
    {
        Expression body = Expression.Call(
            Expression.Convert(s_sharedParam, method.DeclaringType), method);
        if (method.ReturnType.IsValueType) // manually box
            body = Expression.Convert(body, typeof(object));
        return Expression.Lambda<Func<object, object>>(body, s_sharedParams).Compile();
    }
    private void writeReport(List<object> rows, MethodInfo[] columns, string dest)
    {
        using (var writer = new System.IO.StreamWriter(dest))
        {
            var delegates = Array.ConvertAll(columns, col => AsFuncObjectObject(col));
            foreach (object row in rows)
            {
                foreach (var m in delegates)
                {
                    writer.Write(m(row).ToString());
                }
                writer.WriteLine();
                writer.Flush();
            }
            writer.Close();
        }
    }
