    int retries = 5;
    while( true )
    {
    	try
    	{
    		DbCommand cmd = GetCommand( sql );
    		using( DbConnection conn = cmd.Connection )
    		{
    			conn.Open();
    			// do stuff
    			break;
    		}
    	}
    	catch
    	{
    		Thread.Sleep( 1000 );
    		if( retries-- <= 0 )
    		{
    			throw;
    		}
    	}
    }
