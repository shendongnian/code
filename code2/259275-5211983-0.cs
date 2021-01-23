    // Somewhere
    Messenger.Default.Register<string>(this, DoSomething);
    // Further
    private void DoSomething(string message)
    {
        // ...
    }
    // Somewhere else
    Messenger.Default.Send(“Hello world”)
