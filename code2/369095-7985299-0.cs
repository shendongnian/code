    using (var cmd = new SqlCommand("select * ... " + textBox1.Text, conn))
    {
        using (var rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
             ...
            }
        }
    }
