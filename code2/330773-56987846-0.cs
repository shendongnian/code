    public sealed class Assert
    {
    	private static Assert that;
    	
    	public static Assert That
    	{
    		get
    		{
    			if (Assert.that == null)
    				Assert.that = new Assert();
    			return Assert.that;
    		}
    	}
    }
