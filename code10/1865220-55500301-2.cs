    public SVE SV_CBSI(int id)
    {
        SVE localSve = new SVE();
        string CommandText = "SELECT * FROM SV WHERE [SVCode]=@id";
        using (SQLiteCommand cmd = new SQLiteCommand(CommandText, conn))
        {
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                localSve.SVName = dr["SVName"].ToString();
                localSve.SVCity = dr["SVCity"].ToString();
                localSve.SVState = dr["SVState"].ToString();
                localSve.SVEmail = dr["SVEmail"].ToString();
                localSve.SVWebsite = dr["SVWebsite"].ToString();
                localSve.SVAddress = dr["SVAddress"].ToString();
                localSve.SVNote = dr["SVNote"].ToString();
            }
            return localSve;
        }
    }
