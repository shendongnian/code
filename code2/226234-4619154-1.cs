    public static MethodInfo GetMethod<T>(
        Expression<Action<T>> methodSelector)
    {
        var body = (MethodCallExpression)methodSelector.Body;
        return body.Method;      
    }
    [TestMethod]
    public void Test1()
    {
        var expectedMethod = typeof(Foo)
            .GetMethod("Bar", new Type[] { typeof(Func<>) });
        var actualMethod = 
            GetMethod<Foo>(foo => foo.Bar<object>((Func<object>)null)
            .GetGenericMethodDefinition();
        Assert.AreEqual(expectedMethod, actualMethod);
    }
