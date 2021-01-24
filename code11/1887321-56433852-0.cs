            SqlDataAdapter sda = new SqlDataAdapter();
            try
            {
                using (SqlCommand cmd = new SqlCommand(commandString, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@BEGIN", SqlDbType.NVarChar).Value = begin;
                    cmd.Parameters.Add("@END", SqlDbType.NVarChar).Value = end;
                    cmd.Parameters.Add("@FORW", SqlDbType.NVarChar).Value = client;
                    sda.SelectCommand = cmd;
                }
            }
            catch (SqlException ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
}
