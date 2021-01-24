    var sql = @"SELECT RTFPressTableID
        FROM RTFPressTables
        WHERE PressCloseTime BETWEEN DATEADD(day, DATEDIFF(day, 0, @Date), '06:00:00') AND DATEADD(day, DATEDIFF(day, 0, @Date), '08:00:00')";
    using (SqlConnection conn = new SqlConnection("Data Source = ; Initial Catalog = ; Integrated Security = True"))
    {
        conn.Open();
        using (SqlCommand command = new SqlCommand(sql, conn))
        {
            command.Parameters.Add("@Date", SqlDbType.Date);
            command.Parameters["@Date"].Value = dateTimePicker1.Value.Date;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
            }
        }
    }
