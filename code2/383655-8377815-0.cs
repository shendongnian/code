    String query = "SELECT COUNT(AD_SID) As ReturnCount FROM AD_Authorization WHERE AD_SID = @userSID ";
    using (OleDbConnection conn = new OleDbConnection(ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("userSID ", userSID.ToString());
            conn.Open();
            int returnCount = (Int32) cmd.ExecuteScalar();
            conn.Close();
        }
    }
