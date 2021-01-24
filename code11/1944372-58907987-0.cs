    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", MyConnection);
    DataTable dt = new DataTable();
    myDataAdapter.Fill(dt);
    DataColumn timeCol = new DataColumn("Time", typeof(string));
    dt.Columns.Add(timeCol);
    timeCol.SetOrdinal(0);
    dt.Rows[0].SetField("Time", "9:00");
    dt.Rows[1].SetField("Time", "10:00");
    dataGridView1.DataSource = dt;
