    using (SqlDataReader timereader = timecommand.ExecuteReader())
    {
        while (timereader.Read())
        {
            // just read the DateTime value as such
            DateTime dt = timereader.GetDateTime(0);
            // then do whatever you need to do with this DateTime value .....
        }
        connection.Close();
    }
