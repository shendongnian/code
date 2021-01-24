    public class ElementActionFactory
    {
        // Somewhere to keep our actions, using tuple to pair up elements
    	private Dictionary<(Elements, Elements), Action> _elementActions;
    
    	public ElementActionFactory()
    	{
            // Initialise the action dictionary
    		_elementActions = new Dictionary<(Elements, Elements), Action>
    		{
    			{(Elements.Fire, Elements.Fire), FireAndFire},
    			{(Elements.Fire, Elements.Water), FireAndWater},
    			{(Elements.Fire, Elements.Earth), FireAndEarth},
    			// etc.
    		};
    	}
    	
    	public void Invoke(Elements element1, Elements element2)
    	{
            // Try to get the action, and if we don't find it...
    		if (!_elementActions.TryGetValue((element1, element2), out var action))
    		{
                // reverse the arguments and try again - this assumes the order is not important
    			if (!_elementActions.TryGetValue((element2, element1), out action))
    			{
    				return; //No action was found
    			}
    		}
    		
            // Actually run the method now
    		action.Invoke();
    	}
    
    	public void FireAndFire()
    	{
    		Console.WriteLine("Fire And Fire");
    	}
    
    	public void FireAndWater()
    	{
    		Console.WriteLine("Fire And Water");
    	}
    
    	public void FireAndEarth()
    	{
    		Console.WriteLine("Fire And Earth");
    	}
    }
