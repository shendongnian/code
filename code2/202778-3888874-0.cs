    public static void EnsureUserHasAccess(this object obj)
    {
        // check permissions, possibly depending on `obj`'s actual type
    }
    public static void DoSomething(this MyClass obj)
    {
        // permissions check
        obj.EnsureUserHasAccess();
        // do something about `obj`
        …
    }
    public static void DoSomethingElse(this MyDifferentClass obj)
    {
        // permissions check
        obj.EnsureUserHasAccess();
        // do something about `obj`
        …
    }
