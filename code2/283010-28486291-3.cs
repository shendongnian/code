    int done = 0;
    public void DoSomething()
    {
        if (Interlocked.Exchange(ref done, 1) == 0)
            Task.Factory.StartNew(_DoSomething);
    }
