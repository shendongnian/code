    public void DoSomething(object a, object b)
    {
        var method = GetType().GetMethod("DoSomethingElse", BindingFlags.Instance | BindingFlags.Public);
        method.Invoke(this, new object[] { a, b });
    }
