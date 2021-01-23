    using (SqlConnection cn = new SqlConnection(sqlConnectionString))
    {
        cn.Open();
    
        using (SqlCommand commandRowCount
    		= new SqlCommand("SELECT COUNT(*) FROM [LBSExplorer].[dbo].[myTable]", cn))
        {
    	    commandRowCount.CommandType = CommandType.Text;
    	    var countStart = (Int32)commandRowCount.ExecuteScalar();
    	    Console.WriteLine("Starting row count: " + countStart.ToString());
        }
    }
