    public void DoSomething()
    {
        BalloonTip b = new BalloonTip();
    
        DoSomethingElse(b);
    }
    
    public void DoSomethingElse(BalloonTip c)
    {
      // c points to the same instance as b in the previous function
    }
