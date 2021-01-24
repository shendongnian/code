        con = new SqlConnection(cs.connetionString);
        con.Open();
        Sql = "SELECT * FROM ItemRate";
        command = new SqlCommand(Sql, con);
        SqlDataReader reader = command.ExecuteReader();
        // remove this line
        // reader.Read();
        while (reader.Read())
        {
            string cat = reader["RateOfInt"].ToString();
            comboBox4.Items.Add(cat);
        }
