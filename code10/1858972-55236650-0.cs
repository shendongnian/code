	using (var sqlConnection = new SqlConnection(connection))
    {
	       using (var command = new SqlCommand(query, sqlConnection))
		   {
				using (var read = command.ExecuteReader())
				{
					// process on your read
				}
		   }
	}
