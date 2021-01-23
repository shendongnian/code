    using System.Data.Common;
    using System.Data.OleDb;
    
    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
    {
    	connection.ConnectionString = ConnectionString;
    	connection.Open();
    	using (DbCommand command = connection.CreateCommand())
    	{
    		command.CommandText = "SELECT * FROM [" + SheetName + "]";
    		using (DbDataReader DR = command.ExecuteReader())
    		{
    			while (DR.Read())
    			{
    			// Read your data here.
    			}
    		}
    	}
    }
