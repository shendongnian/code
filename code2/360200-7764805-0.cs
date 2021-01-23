    using (var conn = new System.Data.SqlClient.SqlConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BC207\test.accdb"))
    using (var comm = conn.CreateCommand())
    {
    	comm.CommandText = "SELECT password FROM HAHA";
        comm.CommandType = CommandType.Text;
    	
        conn.Open();
    
        var returnValue = comm.ExecuteScalar();
    	
    	MessageBox.Show(returnValue.ToString());
    }
