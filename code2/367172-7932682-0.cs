    static MyClass()
    {
        // Cycle through all the public instance methods.
        // Should filter down to make sure signatures match.
        foreach (MethodInfo methodInfo in typeof(MyClass).
            GetMethods(BindingFlags.Public | BindingFlags.Instance))
        {
            // Create the parameter expression.
            ParameterExpression parameter = Expression.
                Parameter(typeof(MyClass), "mc");
    
            // Call the method.
            MethodCallExpression body= Expression.Call(pe, methodInfo);
    
            // Compile into a lambda.
            Action<MyClass> action = Expression.Lambda<Action<MyClass>>(
                body, parameter).Compile();
    
            // Add to the dictionary.
            methods.Add(methodInfo.Name, action);
        }
    }
