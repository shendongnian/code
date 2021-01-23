    public void DecideAndCall(string identifier)
    {
        string methodName = "doSomething_" + identifier;
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        MethodInfo mi = this.GetType().GetMethod(methodName, flags);
        // ...
    }
