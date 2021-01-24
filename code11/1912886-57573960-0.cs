 using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    result = cmd.ExecuteScalar().ToString();
                }
                catch(NullReferenceException n)
                {
                    result = "";
                }
            } 
`ExecuteScaler` gets you the first column of the first row and additional columns are ignored. Use the value from `result` in your `SendKeys()`
