            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection("CONNECTION_STRING");
            cmd.CommandText = "SELECT * FROM ....";
            try
            {
                cmd.Connection.Open();
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    // ....
                }
                catch
                {
                    // other exception
                }
                finally
                {
                    cmd.Connection.Close();
                }
            } 
            catch
            {
                // connection error
            }
