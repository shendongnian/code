     public void LoadData()
        {
    DataTable NewDataTable = new DataTable();
    
            string FullOuterQuerry = "Your reworked querry";
            MySqlDataAdapter MySQLDA= new MySqlDataAdapter(FullOuterQuerry, connection);
            MySQLDA.Fill(NewDataTable);
            MySQLDA.Dispose();
            dataGridView1.DataSource = NewDataTable;
        }
