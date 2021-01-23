    // Automatically dispose  the connection when done
    using(SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString)) {
        try {
            connection.Open();
    
            // query to check whether value exists
            string sql =  @"SELECT dataset1 
                            FROM   dbo.ste 
                            WHERE  project = 'whatever'
                                   AND date = '2010-11-30'";
    
            // create the command object
            using(SqlCommand command = new SqlCommand(sql, connection)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    // if the result set is not NULL
                    if(reader.HasRows) {
                        // update the existing value + the value from the text file
                    }
                    else {
                        // insert a value from a text file
                    }
                }
            }
        }
        finally {
            // always close connection when done
            if(connection.State != ConnectionState.Closed) {
                connection.Close();
            }
        }
    }
