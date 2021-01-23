	using System.Data;
	using System.Data.SqlClient;
	namespace foo
	{
		class bar
		{
			static public void ExecuteStoredProc()
			{
				var connectionString = "Data Source=.;Integrated Security=True;Pooling=False;Initial Catalog=YourDatabaseName";
				using (var connection = new SqlConnection(connectionString))
				using (var command = new SqlCommand("dbo.YourStoredProcedure", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@YourParameterName", "YourParameterValue");
					connection.Open();
					// wire up an event handler to the connection.InfoMessage event
					connection.InfoMessage += connection_InfoMessage;
					var result = command.ExecuteNonQuery();				
					connection.Close();
				}
			}
			static void connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
			{
				// this gets the print statements (maybe the error statements?)
				var outputFromStoredProcedure = e.Message;				
			}
		}
	}
