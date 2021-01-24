	public void StartProcess()
	{
		/*This part isn't exacly the same in my program but the point is the same: create a SqlConnection*/
		string providerName = "System.Data.SqlClient";
		string serverName = ".";
		string databaseName = "SchoolDB";
		// Initialize the connection string builder for the SQL Server provider.
		SqlConnectionStringBuilder sqlBuilder =
			new SqlConnectionStringBuilder();
		// Set the properties for the data source.
		sqlBuilder.DataSource = serverName;
		sqlBuilder.InitialCatalog = databaseName;
		sqlBuilder.IntegratedSecurity = true;
		using (SqlConnection con = new SqlConnection(sqlBuilder.ToString()))
		{
		/*From this point my tested code has exactly the same construction*/
			con.Open();
			using (SqlTransaction transaction = con.BeginTransaction())
			{
				int take = 10000;
				int index = 1;
				while (index <= needToProcess)
				{
					localScopeCtx =  new ApplicationDbContext(trans, false);
					var records = GetRecords(take)
					List<obj> recordsToDelete;
					ProcessRecords(take, out recordsToDelete);
					
					localScopeCtx.Records.RemoveRange(recordsToDelete);
					
					localScopeCtx.SaveChanges();
					localScopeCtx.Dispose()
				}
				trans.Commit();
			}
		}
    }
