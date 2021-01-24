    public static string ManagerFindid() 
    { 
    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) 
    	{ 
    		var select = cnn.Query("select id from utenti"); 
    		if (select.Any()) 
    		{ 
    			return select[0].ToString();
                // or do something with all the items in your list               
                foreach(string value in select)
                {
                     //add value into list view
                }
    		} 
    		else 
    		{
                //this is hit when there are no items returned from the select query 
    			return "Nothing Returned from Query";
    		} 
    } 
