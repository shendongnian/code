    while (reader.Read())
    {
        Status = reader["status"].ToString();
        try{
        Event_Start_Date1 = reader.GetDateTime(reader.GetOrdinal("event_start_date1"));
        }
    catch{
        Event_Start_Date1 = //some other thing
    }
