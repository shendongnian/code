    void Method(Action action)
    {
    }
    ...
    Method((() => { Console.WriteLine("OK"); }));
