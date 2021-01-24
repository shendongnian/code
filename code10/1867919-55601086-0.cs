	public static void InsertSubject(Przedmiot subject)
	{
		using (SqlConnection conn = new SqlConnection("Connection String"))
		{
			try
			{
				SqlCommand command = new SqlCommand("dbo.InsertSubject", conn) { CommandType = CommandType.StoredProcedure };
				command.Parameters.Add(new SqlParameter("@IdSubject", subject.IdSubject));
				command.Parameters.Add(new SqlParameter("@Name", subject.subject));
				conn.Open();
				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				// handle exceptions
			}
		}
	}
	
