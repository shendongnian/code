    public static MethodInfo GetMethod<T>(Expression<Action<T>> action)
    {
        var body = action.Body as MethodCallExpression;
        return body.Method.GetGenericMethodDefinition();      
    }
    [TestMethod]
    public void Test1()
    {
        var method = 
            GetMethod<Foo>(foo => foo.Bar<object>((Func<object>)null);
        Assert.IsNotNull(method);
    }
