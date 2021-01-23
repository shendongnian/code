    // Note “static”
    public static void DoSomething(dynamic instance, object a, object b)
    {
        // This will call whatever “DoSomethingElse” method exists on the type
        // that “instance” has *at run-time*
        instance.DoSomethingElse(a, b);
    }
