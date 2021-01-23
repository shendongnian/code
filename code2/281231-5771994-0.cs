    if (date.DayOfWeek != DayOfWeek.Sunday)
    {
        cmd.Parameters["@Date"].Value = date.ToString("d");
               
        date = date.NextDay();
        sqlConn.Open();
        cmd.ExecuteNonQuery();
        sqlConn.Close();
     }
