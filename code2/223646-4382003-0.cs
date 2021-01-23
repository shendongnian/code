    void MyMethod(Action<object[]> aMethod, params object[] aParams)
    {
        aMethod(aParams);
    }
    void Print(params object[] output)
    {
        foreach (var o in output)
            Console.WriteLine(o);
    }
