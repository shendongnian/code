    using (var cn = new MySqlConnection("..."))
    using (var cmd = new MySqlCommand("@INSERT INTO Table(field).... ", cn))
    {
        cmd.Parameters.Add(...);
        cn.Open();
        using (var rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                //...
            }
        }
    }
