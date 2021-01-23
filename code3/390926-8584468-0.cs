    Dictionary production = new Dictionary<string, int>();
    string query= "select distinct nameProduct, price from product";
    using (SqlCeCommand cmd = new SqlCeCommand(sql, dbConn))
    {
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                production[(string)reader["nameProduct"]] = (int)reader["price"];
            }
        }
    }
