    static void CallFunc(string mymethod)
    {
        // Get a type from the string 
        Type type = typeof(TypeThatContainsCommonFunctions);
        // Create an instance of that type
        object obj = Activator.CreateInstance(type);
        // Retrieve the method you are looking for
        MethodInfo methodInfo = type.GetMethod(mymethod);
        // Invoke the method on the instance we created above
        methodInfo.Invoke(obj, null);
    }
