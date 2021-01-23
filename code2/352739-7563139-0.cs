        SqlConnection conn = new SqlConnection(yourConnectionString);
        SqlCommand cmd = new SqlCommand("select col from yourtable", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            byte[] bytes = (byte[])reader[0];
        }
        reader.Close();
        conn.Close();
