    DateTime when = DateTime.Parse(ddate); // better to use ParseExact and formally state the format you are using
    const string query1 = "SELECT * FROM Flight_Schedule S WHERE S.departure_date = @departureDate";
    using (SqlConnection connect = new SqlConnection(conn))
    {
        using (SqlCommand cmd = new SqlCommand(query1, connect))
        {
            cmd.Parameters.AddWithValue("departureDate", when);
            connect.Open();
            using (SqlDataReader result = cmd.ExecuteReader())
            {
               ... etc
            }
        }
    }
