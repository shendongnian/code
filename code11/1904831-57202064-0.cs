    public void Foo()
    {
        bool retVal = Bar((x,z) => x.Any(y => y.Contains(z))); // Where z is "my variable" (below)
    }
    public bool Bar(List<MyObject> list, Func<List<MyObject>, string, bool> pFunc)
    {
        return pFunc(list, "a variable");
    }
