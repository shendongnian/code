    if (date.DayOfWeek != DayOfWeek.Sunday)
    {
        cmd.Parameters["@Date"].Value = date.ToString("d");
               
        sqlConn.Open();
        cmd.ExecuteNonQuery();
        sqlConn.Close();
     }
     date = date.NextDay();
