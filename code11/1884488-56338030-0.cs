    mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM a_Users WHERE DTGModified > " + LastUpdated.ToString() + ";", connection); // Query the database
    DataTable DT = new DataTable(); // Create new DataSet
    mySqlDataAdapter.Fill(DT); // Fill the Dataset with the information gathered above
    LastUpdated = DateTime.Now.ToString("yyyyMMddHHmmss"); // Save the time we retrieved the database
    
    foreach (DataRow dr in (dataGridView1.DataSource as DataTable).Rows)
    {
        foreach(DataRow DTdr in DT.Rows)
        {
            if (dr["ID"].ToString() != DTdr["ID"].ToString()) continue;
    
            dr.ItemArray = DTdr.ItemArray;
        }
    }
