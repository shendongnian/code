    public void PassMeAMethod(string text, Action method)
    {
      DoSomething(text);
      // call the method
      method();    
    }
    
    public void methodA()
    {
    //Do stuff
    }
    
    
    public void methodB()
    {
    //Do stuff
    }
    
    public void Test()
    {
    //Explicit
    PassMeAMethod("calling methodA", new Action(methodA));
    //Implicit
    PassMeAMethod("calling methodB", methodB);
    
    }
