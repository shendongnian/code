        using(SqlConnection conn = new SqlConnection(connectionStringArg))
        using(SqlCommand command = new SqlCommand("select applicationname from tbl_settings")) {
            command.Connection = conn;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.read()) {
                return reader.GetString(0);
            }
            return null;
        }
