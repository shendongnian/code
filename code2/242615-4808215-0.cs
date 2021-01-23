    private readonly Regex _sqlScriptSplitRegEx = new Regex( @"^\s*GO\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled );
    public void ExecuteSqlScript( string scriptText )
    {
    	if ( string.IsNullOrEmpty( scriptText ) )
    		return;
    
    	var scripts = _sqlScriptSplitRegEx.Split( scriptText );
    	using ( var conn = new SqlConnection( "connection string" ) )
    	{
    		using ( var ts = new TransactionScope( TransactionScopeOption.Required, new TimeSpan( 0, 10, 0 ) ) )
    		{
    			foreach ( var scriptLet in scripts )
    			{
    				if ( scriptLet.Trim().Length == 0 )
    					continue;
    
    				using ( var cmd = new SqlCommand( scriptLet, conn ) )
    				{
    					cmd.CommandTimeout = this.CommandTimeout;
    					cmd.CommandType = CommandType.Text;
    					cmd.ExecuteNonQuery();
    				}
    			}
    
    			ts.Complete();
    		}
    	}
    }
