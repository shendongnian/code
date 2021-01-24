    private static async Task ScaleDatabaseUp()
    {
                var constring = Environment.GetEnvironmentVariable("SQL_DB");
                var query = string.Format(@"
    ALTER DATABASE <DATABASENAME>
        MODIFY (SERVICE_OBJECTIVE = 'PRS1'); --PRS1");
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
     
                }           
    }
