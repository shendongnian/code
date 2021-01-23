    public T HandleServiceCall<T>(Expression<Func<T>> serviceMethod)
    {
        try
        {
            return serviceMethod();
        }
        finally
        {
            var serviceMethodInfo = ((MethodCallExpression)serviceMethod.Body).Method;
            Console.WriteLine("The '{0}' service method was called", serviceMethodInfo.Name);
        }
    }
