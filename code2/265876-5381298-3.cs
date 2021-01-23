    SqlCeConnection con = new SqlCeConnection();
    con.ConnectionString =  yeniApplicationDatabase.Properties.Settings.Default.DatabaseEdaConnectionString;
    con.Open();
    SqlCeCommand com = new SqlCeCommand("INSERT INTO Images (ImagePath) VALUES ('book')", con);
    
    com.ExecuteNonQuery();
    
    com.Dispose();
    con.Close();
