    conn.Open();
    using (var cmd = conn.CreateCommand())
    {
       cmd.CommandType = CommandType.Text;
       cmd.CommandText = "SELECT Count(*) FROM CustomerLogs";
       using (var reader = cmd.ExecuteReader())
       {
          reader.Read(); // Advance one record
          ViewBag.CountLog = reader.GetInt32(0);
       }
    }
