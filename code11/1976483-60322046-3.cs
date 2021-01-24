    conn.Open();
    using (var cmd = conn.CreateCommand())
    {
       cmd.CommandType = CommandType.Text;
       cmd.CommandText = "SELECT Count(*) FROM Customer where UserId = @UserId";
       cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = currentUserId;
       using (var reader = cmd.ExecuteReader())
       {
          reader.Read(); // Advance one record
          ViewBag.CountLog = reader.GetInt32(0);
       }
    }
