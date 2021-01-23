    public static class UtilityExtensions
    {
    	public static void ThrowIfNull( this object obj, string argName )
    	{
    		if ( obj == null )
    		{
    			throw new ArgumentNullException( argName );
    		}
    	}
    }
