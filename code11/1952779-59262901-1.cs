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
---
Note: the use of `Expression` here is to deal with the ambiguity of the method signature, and the lack of generics. If the input type is well known as a `T`, and the return type is known (presumably either `string` or `object`), then you can use `Delegate.CreateDelegate` directly, simply specifying `null` as the target object. `Delegate.CreateDelegate` allows a special usage where if you pass in a `null` target as the target instance of an instance method, **and** you specify a delegate type with one-too-many parameters, then it treats the first parameter as the per-call target instance. So; if you are dealing with generic `T` and `string`, you could use simply:
 c#
private void WriteReport<T>(List<T> rows, MethodInfo[] columns, string dest)
{
    // ...
    var delegates = Array.ConvertAll(columns,
        col => (Func<T, string>)Delegate.CreateDelegate(typeof(Func<T, string>), col));
    foreach (T row in rows)
    {
        foreach (var m in delegates)
        {
            writer.Write(m(row));
    // ...
