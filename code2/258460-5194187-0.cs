    public delegate void SomethingHappenedEventHandler(object sender, object args);
    public event SomethingHappenedEventHandler SomethingHappened;
    public void DoSomethingElse(object a, object b)
    {
        Console.WriteLine("Yay! " + a + " " + b);
    }
    // If the signature exactly matches the delegate, just use the method name
    SomethingHappened += DoSomethingElse;
    public void DoSomethingDifferent(object a)
    {
        Console.WriteLine("Yay! " + a);
    }
    // Otherwise, just use a lambda expression
    SomethingHappened += (a, b) => DoSomethingDifferent(a);
