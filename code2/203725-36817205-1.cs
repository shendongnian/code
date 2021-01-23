	var connStr = "";
	using (var connection = new SqlConnection(connStr)) 
	{
		var startTime = DateTime.Now;
		connection.Open();
		var transaction = connection.BeginTransaction();
		try
		{
			//var connStr = connection.ConnectionString;
			using (var sbCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
			{
				sbCopy.BulkCopyTimeout = 0;
				sbCopy.BatchSize = 10000;
				sbCopy.DestinationTableName = "Foobars";
				var reader = Foobars.AsDataReader();
				sbCopy.WriteToServer(reader);
			}
			transaction.Commit();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			transaction.Rollback();
		}
		finally
		{
			transaction.Dispose();
			connection.Close();
			var endTime = DateTime.Now;
			Console.WriteLine("Upload time elapsed: {0} seconds", (endTime - startTime).TotalSeconds);
		}
	}
