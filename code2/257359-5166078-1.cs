        string q = "SELECT Replace(names,'{0}','{1}') AS Expr1 FROM table1";
    //You can provide any values instead of LION and KISS
        string query = string.format(q,"LION","KISS") 
    
        using(OleDbConnection cnn = (OleDbConnection)DatabaseConnection.Instance.GetConnection())
        {
        	cnn.Open();  
        	using(OleDbCommand cmd = new OleDbCommand(query, cnn))
                {
        		OleDbDataReader reader = cmd.ExecuteReader();
        		while(reader.Read())
        		{
        			Console.WriteLine(reader["Expr1"].toString());
        		}
                }
        }
