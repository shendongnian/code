    private function Search( string make, string model, ... )
    {
    	var sql = new StringBuilder();
    	sql.AppendLine( "Select .... " );
    	sql.AppendLine( "From MyTable" );
    	sql.AppendLine( "Where 1=1" ); //this is just to add the Where keyword
    	
    	var parameters = List<DbParameter>();
    	if ( !string.IsNullOrEmpty( make ) )
    	{
    		sql.AppendLine( " And Make = @Make " );
    		parameters.AddWithValue( "@Make", make );
    	}
    	
    	if ( !string.IsNullOrEmpty( model ) )
    	{
    		sql.AppendLine( " And Model = @Model " );
    		parameters.AddWithValue( "@Model", model );
    	}
    	...
    }
