    using(var conn = new SqlCeConnection("Data Source=|DataDirectory|CeoDatabase.sdf;Password=CeoDB;Persist Security Info=True"))
    {
        conn.Open();
    
        var comm = new SqlCeCommand("SELECT Names FROM Barlar", conn);
        SqlCeDataReader reader = comm.ExecuteReader();
    
        while(reader.Read())
            listbox.Items.Add(reader["Names"]);
    }
