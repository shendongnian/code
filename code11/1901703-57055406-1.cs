    public void foo()
    {
        Task.Delay(3000).ContinueWith(t=> bar());
    }
    
    public void bar()
    {
        // do stuff
        foo();   //This will run the next bar() in 3 seconds from now 
    }
