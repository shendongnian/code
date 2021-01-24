    List<MulticastDelegate> multicastDelegates = new List<MulticastDelegate>();
    multicastDelegates.Add(new Action(() => Console.WriteLine("Hello World!")));
    multicastDelegates.Add(new Action<int>(x => Console.WriteLine(x)));
    foreach (var multicastDelegate in multicastDelegates)
    {
        if (multicastDelegate is Action<int> actionInt)
        {
           actionInt(1);
        }
        else if (multicastDelegate is Action action)
        {
           action();
        }
    }
