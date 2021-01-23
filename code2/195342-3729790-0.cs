    public IMyContract GetInterface()
    {
      using (MyObject obj = new MyObject())
      {
        obj.DoSomething();
        return (IMyContract)obj;
      }
    }
