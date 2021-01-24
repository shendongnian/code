    foreach (ListItem item in CheckBoxList1.Items) 
    {
        using(SqlConnection sc = new SqlConnection(con))
        {
            sc.Open(); 
            string cmdText = "SELECT * FROM Statistic WHERE SensorID=@id";
            if (item.Selected) 
            {
                // Moved the actual query inside the check for the item.Selected
                // so you are calling the db only for the items that you want to use
               SqlCommand cmd = new SqlCommand(cmdText, sc); 
               cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = item.Value;
               using(SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read()) 
                   {
                       DataListe dali = new DataListe();
                       dali.SensorID = (string)reader["SensorID"];
                       dali.BatteryLife = (string)reader["BatteryLife"];
                       dali.YearInUsage = (string)reader["YearInUsage"];
                       dali.NumberOfUsage = (int)reader["NumberOfUsage"];
                       dali.Occupations = (string)reader["Occupations"];
                       dali.Placement = (string)reader["Placement"];
                       dali.Zip = (int)reader["Zip"];
                       dali.City = (string)reader["City"];
                       dl.Add(dali); 
                 }
            }
        }
    }
