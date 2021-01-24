    public static int CountFlags( Enum days )
    {
    	int flagsSet = 0;
    	foreach( var value in Enum.GetValues( days.GetType() ) )
    	{
    		if( days.HasFlag( (Enum)value ) )
    	    {
    			++flagsSet;
    		}
    	}
    	
    	return flagsSet;
    }
