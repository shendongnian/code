    // Open the same connection with the same connection string.
    using (SqlCeConnection con = new SqlCeConnection(DatabaseControl.conString))
    {
        con.Open();
        // Read specific values in the table.
        using (SqlCeCommand com = new SqlCeCommand("SELECT Result FROM RamResults WHERE Date = @Date", con))
        {
            com.Parameters.AddWithValue("@Date", Form1.date);
            SqlCeDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                int resultsoutput = reader.GetInt32(0);
                MessageBox.Show(resultsoutput.ToString());
            }
        }
    }
