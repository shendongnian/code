    public string connStr = "server=localhost;user=root;database=clg;port=3306;password=''";
    DataTable mySqlTable = new DataTable();
    using(MySqlConnection conn = new MySqlConnection(connStr))
    {
        conn.Open();
        string sql = "SELECT * FROM Student";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr= cmd.ExecuteReader();
        mySqlTable.Load(rdr);
        dataGridView1.DataSource = mySqlTable;
        
    }
