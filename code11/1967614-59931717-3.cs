    public void LoadData()
    {
        DataTable NewDataTable = new DataTable();
    
        string FullOuterQuery = "Your reworked query";
        MySqlDataAdapter MySQLDA= new MySqlDataAdapter(FullOuterQuery, connection);
        MySQLDA.Fill(NewDataTable);
        MySQLDA.Dispose();
        dataGridView1.DataSource = NewDataTable;
    }
