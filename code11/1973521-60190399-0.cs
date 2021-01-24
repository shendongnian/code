    public static string ManagerFindid() 
    { 
    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) 
    	{ 
    		var select = cnn.Query("select id from utenti"); 
    		if (select.Any()) 
    		{ 
    			return select[0].ToString();
    		} 
    		else 
    		{
    			return "Nothing Returned from Query";
    		} 
    } 
