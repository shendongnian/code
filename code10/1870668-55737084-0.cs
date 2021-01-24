    public void LoadData(DataGridView Grid, String fields)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select " + fields + " from " + table;
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DB.Fill(DS);
            DT = DS.Tables[0];
            Grid.DataSource = DT;
            sql_con.Close();
        }
