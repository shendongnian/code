    if (textBox1.Text != "")
    {
        string search = textBox1.Text;
        int s = Convert.ToInt32(search);
        string conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Local Docs\\Temp\\Data.accdb";
        string query = "SELECT playerBatStyle FROM Player where playerID=@playerID";
        OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, conn);
        dAdapter.SelectCommand.Parameters.AddWithValue("@playerID", s);
        DataTable dTable = new DataTable();
        dAdapter.Fill(dTable);
        dataGridView1.DataSource = dTable;
        dataGridView1.DataBind(); 
    }
