    public IEnumerable<SomeType> Create()
    {
      for(int i = 0; i != 10; ++i)
      {
        //code that creates the object here.
        //Lets say it gets put into a variable called ret
        yield return ret;
      }
    }
    public void Use()
    {
      foreach(SomeType st in Create())
      {
        //use st here.
      }
    }
