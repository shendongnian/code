    public void DoStuff<T>(MyBaseClass objA, MyBaseClass objB)
        where T : struct, IComparable, IConvertible
    {
        // ...
    }
