    public void ReplaceColumnA(string value1, string value2)
    {
    	using(OleDbConnection connection1 = (OleDbConnection)DatabaseConnection.Instance.GetConnection())
    	{
    		connection1.Open();  
    		using(OleDbCommand sqlcmd2 = new OleDbCommand("update [t] set [a]=@value1 where [a]=@value2", connection1))
    		{
    			sqlcmd2.Parameters.AddWithValue("value1", value1); 
    			sqlcmd2.Parameters.AddWithValue("value2", value2);
    			sqlcmd2.ExecuteNonQuery();
    		}
    	}
    }
