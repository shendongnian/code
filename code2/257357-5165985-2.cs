    public void ReplaceColumnA(string oldvalue, string newvalue)
    {
    	using(OleDbConnection connection1 = (OleDbConnection)DatabaseConnection.Instance.GetConnection())
    	{
    		connection1.Open();  
    		using(OleDbCommand sqlcmd2 = new OleDbCommand("queryname", connection1))
    		{
    			sqlcmd2.Parameters.AddWithValue("param1", newvalue); 
    			sqlcmd2.Parameters.AddWithValue("param2", oldvalue);
    			sqlcmd2.ExecuteNonQuery();
    		}
    	}
    }
