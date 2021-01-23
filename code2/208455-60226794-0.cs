                    string connectionString = ConfigurationManager.ConnectionStrings["NameOfYourSqlConnectionString"].ConnectionString;
                    using (var _connection = new SqlConnection(connectionString))
                    {
                        _connection.Open();
    
                        using (SqlCommand command = new SqlCommand("SELECT SomeColumnName FROM TableName", _connection))
                        {
    
                            SqlDataReader sqlDataReader = command.ExecuteReader();
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    string YourFirstDataBaseTableColumn = sqlDataReader["SomeColumn"].ToString(); // Remember Type Casting is required here it has to be according to database column data type
                                    string YourSecondDataBaseTableColumn = sqlDataReader["SomeColumn"].ToString();
                                    string YourThridDataBaseTableColumn = sqlDataReader["SomeColumn"].ToString();
    
                                }
                            }
                            sqlDataReader.Close();
                        }
                        _connection.Close();
