    public X { get; set; }
    public void InvokeX()
    {
      X.DoSomething(); // if X value is null, you will get a NullReferenceException
    }
