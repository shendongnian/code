    public void CompleteRegProcessPass(string role, string chooseFleet1) =>
    	CompleteRegProcessPassImpl(role, chooseFleet1);
    
    public void CompleteRegProcessPass(string role, string chooseFleet1, string chooseFleet2) =>
    	CompleteRegProcessPassImpl(role, chooseFleet1, chooseFleet2);
    
    private void CompleteRegProcessPassImpl(string role, params string[] chooseFleet)
    {
    	...
        foreach(var cf in chooseFleet)
        {
            objCommon.ScrollInToViewAndClick(cf);
        }
        ...
    }
