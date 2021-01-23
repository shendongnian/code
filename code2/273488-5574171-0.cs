    string connString = ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
    using (SqlConnection conn = new SqlConnection(connString))
        {
            String sql = "SELECT name FROM Customer WHERE customer_id = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;
            String result = "";
            try
            {
                conn.Open();
                result = (string)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
