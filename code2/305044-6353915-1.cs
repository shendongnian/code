    using (OleDbConnection con = new OleDbConnection(...))
    {
    	using (OleDbCommand com = new OleDbCommand(sqlString, con))
        {
    		//code
    	}
    }
