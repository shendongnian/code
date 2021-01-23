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
                finally
                {
                    cmd.Connection.Close();
                }
            } 
            catch
            {
                // connection or other error
            }
