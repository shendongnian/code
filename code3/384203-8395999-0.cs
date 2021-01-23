    public bool UserExists(string UserName)
    {
        DataTable table = new DataTable("table");
        string connectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "SELECT COUNT(UserName) FROM User WHERE UserName = " + UserName;
            try
            {
                connection.Open();
                object userName = command.ExecuteScalar();
                return userName != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
