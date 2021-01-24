    var goodForVisit = false;
    int visitedCount;
    int offerDayCount;
    var endDate = DateTime.MinValue;
    DateTime startDate = DateTime.MinValue;
    using (SqlCommand com = new SqlCommand("select * from [enddate] where ID=@ID", con))
    {
        com.Parameters.AddWithValue("@ID", ID.Text);
        using (SqlDataReader reader = com.ExecuteReader())
        {
            if (reader.Read())
            {
                //get information from enddate table
                var offer = reader["offer"].ToString();
                offerDayCount = (int)reader["day"];
                startDate = (DateTime)reader["Startdate"];
                if (reader["enddate"] != null)
                    endDate = (DateTime)reader["enddate"];
                
                if (reader["enddate"] == null && offer == "dayly")
                {
                    endDate = DateTime.Now.Date;
                }
                //count the visit from checkin table
                using (var com2 = new SqlCommand("SELECT COUNT(*) as count From checkin WHERE Time >= @STARTDATE and (Time <= @ENDDATE)"))
                {
                    com.Parameters.AddWithValue("@STARTDATE", startDate);
                    com.Parameters.AddWithValue("@ENDDATE", endDate);
                    using (SqlDataReader reader2 = com2.ExecuteReader())
                    {
                        if (reader2.Read())
                        {
                            visitedCount = (int)reader2["count"];
                            if (offer == "dayly" && visitedCount < offerDayCount)
                                goodForVisit = true;
                            if (offer == "monthly" && DateTime.Now >= startDate && DateTime.Now <= endDate)
                                goodForVisit = true;
                        }
                    }
                }
            }
        }
    }
    if (goodForVisit)
    {
        using (SqlCommand com1 = new SqlCommand("INSERT INTO [checkin] (ID,time,username) VALUES (@ID,@time,@username)", con))
        {
            com1.Parameters.AddWithValue("@ID", ID.Text);
            com1.Parameters.AddWithValue("@time", txttime.Text);
            com1.Parameters.AddWithValue("@username", txtusername.Text);
            com1.ExecuteNonQuery();
        }
        MetroFramework.MetroMessageBox.Show(this, "Check In Sucssesfuly ................... ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else
    {
        MetroFramework.MetroMessageBox.Show(this, "this ID Expired .....................", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
