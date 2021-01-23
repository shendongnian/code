            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection("CONNECTION_STRING");
            cmd.CommandText = "SELECT * FROM ....";
            // cmd.CommandType = System.Data.CommandType.Text;
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
            catch (SqlException ex)
            {
                // ex.Class contains the ErrorCode, depends on your dataprovider
                foreach (SqlError error in ex.Errors)
                {
                    // error.LineNumber
                    // error.Message
                }
            }  
