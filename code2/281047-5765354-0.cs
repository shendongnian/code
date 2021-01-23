    public delegate int DoSomething();
    private event DoSomething _somethingHappened;
    public event DoSomething SomethingHappened
    {
      add { _somethingHappened += value; }
      remove { _somethingHappened -= value; }
    }
