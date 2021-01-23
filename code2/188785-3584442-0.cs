    Dictionary<int[], Action> actionMap = new Dictionary<int[], actionMap>
    {
      {new[]{1067,19417}, ProcessA},
      {new[]{35075, 35085}, ProcessB}
    }
    
    public void ProcessA()
    {
      // do something;
    }
    
    public void ProcessB()
    {
      // do something else;
    }
    
    public void Process(int zipCode)
    {
      var action = actionMap.FirstOrDefault(a => zipCode >= a.Key[0] && zipCode <= a.Key[1]);
      if (action != null)
      {
         action.Value();
      }
    }
