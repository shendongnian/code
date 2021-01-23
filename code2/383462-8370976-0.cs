    using(SqlDataReader rdr = cmd.ExecuteReader())
    {
        while (rdr.Read())
        {
            string value1 = rdr.GetString(0);
            string value2 = rdr.GetString(1);
            string value3 = rdr.GetString(2);
        }
    }
