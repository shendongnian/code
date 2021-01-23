    [Obsolete("Do Not Use", true)]
    public static class Extensions
    {
    	public static int Squared(this Dummy Dummy)
    	{
    		return Dummy.x * Dummy.x;
    	}
    
    	public static int Squared2(Dummy Dummy)
    	{
    		return Dummy.x * Dummy.x;
    	}
    
    }
