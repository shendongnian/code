    DataTable result = new DataTable();
    using (SqlConnection conn = new SqlConnection(MyConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand(MyQueryText, conn))
        {
            // set CommandType, parameters and SqlDependency here if needed
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                result.Load(reader);
            }
        }
    }
