    void DoesntCompile()
    {
        A a;
        string x = a.ToString(); // Can't use a - it's not definitely assigned
    }
    void CompilesButGoesBang()
    {
        A a = null;
        string x = a.ToString(); // Throws a NullReferenceException
    }
