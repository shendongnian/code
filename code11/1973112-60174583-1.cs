	private static void ExecuteSqlTransaction(string connectionString)
	{
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			connection.Open();
			using (SqlCommand command = connection.CreateCommand())
			using (SqlTransaction transaction connection.BeginTransaction("SampleTransaction"))
			{
				// Must assign both transaction object and connection
				// to Command object for a pending local transaction
				command.Connection = connection;
				command.Transaction = transaction;
				command.CommandText =
					"Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
				command.ExecuteNonQuery();
				command.CommandText =
					"Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
				command.ExecuteNonQuery();
				// Attempt to commit the transaction.
				transaction.Commit();
				Console.WriteLine("Both records are written to database.");
			}
		}
	}
