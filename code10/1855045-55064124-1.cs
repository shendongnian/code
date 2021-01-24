    protected DataTable ExecuteSelectQuery(String query, params SqlParameter[] sqlParameters)
    {
        using (SqlCommand command = new SqlCommand())    
            try
            {
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.Connection = OpenConnection();
                
                DataTable dataTable = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    adapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlException e)
            {
                return null;
                throw new Exception("Error :" + e.Message);
            }
            finally
            {
                CloseConnection();
            }
    }
    
