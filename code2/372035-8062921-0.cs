	Boolean succeeded = false;
	while (!succeeded)
	{
		try
		{
			// Call a MS SQL stored procedure (MS SQL 2000)
			// Stored Procedure may deadlock 
		}
		catch (Exception)
		{
			// Log
		}
		finally
		{
			// Clean up DB
			succeeded = true;
		}
	}
