    public void MyMessyFunction()
    {
      // ...
      foreach(string foo in bar)
      {
        DoUglyStuff(foo, bar);
      }
    
      // ...
    }
    #region Stuff I want to hide
    public void DoUglyStuff(string foo, List<string> bar)
    {
      // Do ugly stuff
    }
    #endregion
