    conn.Open();
    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    while (reader.Read())
    {
      if (reader.HasRows)
      {
        singleEvent.StartDateTime = (DateTime)(reader["StartDateTime"]);
        singleEvent.EventID = (long)reader["EventID"];
        eventList.Add(singleEvent);
      }
    }
