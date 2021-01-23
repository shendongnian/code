    public static void Main()
    {
    	DataTable t = new DataTable();
    	t.Columns.Add(new DataColumn("Col1"));
    	t.Columns.Add(new DataColumn("Col2"));
    	t.Columns.Add(new DataColumn("Col3"));
    	for (int i = 0; i < 5; i++)
    	{
    		var r1 = t.NewRow();
    		r1["Col1"] = "1" + i.ToString();
    		r1["Col2"] = "2" + i.ToString();
    		r1["Col3"] = "3" + i.ToString();
    		t.Rows.Add(r1);
    	}
    	t.AcceptChanges();
    	var connectionString = new SqlConnectionStringBuilder();
    	connectionString.DataSource = "localhost";
    	connectionString.InitialCatalog = "testdb";
    	connectionString.IntegratedSecurity = true;
    
    	using (SqlConnection sqlConn = new SqlConnection(connectionString.ToString()))
    	{
    		sqlConn.Open();
    		using (SqlTransaction sqlTran = sqlConn.BeginTransaction())
    		{
    			string deleteQuery = "delete from MyTable";	// just delete them all
    			SqlCommand sqlComm = new SqlCommand(deleteQuery, sqlConn, sqlTran);
    			sqlComm.ExecuteNonQuery();
    			using (SqlBulkCopy sqlcopy = new SqlBulkCopy(sqlConn, SqlBulkCopyOptions.Default, sqlTran))
    			{
    				sqlcopy.BatchSize = 10;
    				sqlcopy.DestinationTableName = "MyTable"; 
    				try
    				{
    					sqlcopy.WriteToServer(t);
    					sqlTran.Commit();
    				}
    				catch (Exception ex)
    				{
    					sqlTran.Rollback();
    				}
    			}
    		}
    	}
    
    }
