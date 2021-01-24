    public void foo()
    {
        Task.Delay(3000).ContinueWith(t=> bar());
    }
    
    public void bar()
    {
        // do stuff
    }
