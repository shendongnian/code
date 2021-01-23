    string insertCommand = "INSERT INTO Users (UserID) VALUES" 
        +""+ "('"+UsersIdentityToinsert+"')";
    string cs = WebConfigurationManager.ConnectionStrings["YourGuruDB"].ConnectionString;
    SqlConnection conn = new SqlConnection(cs);
    SqlCommand cmd = new SqlCommand(insertCommand, conn);
    conn.Open();
    cmd.ExexuteNonQuery();
    conn.Close();
