    [DebuggerStepThrough]
    static A GetA<A>(IList<A> aCollection, string b) where A : Test
    {
        DoNoOp();
        return aCollection.FirstOrDefault(a => a.b == b);
    }
    static void DoNoOp()
    {
        // noop
        Console.WriteLine("got here");
    }
