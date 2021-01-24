public void Refresh(object sender, EventArgs e)
{
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Documents\test1.mdb";
            OleDbCommand comm = new OleDbCommand("SELECT * FROM data1;", conn);
            conn.Open();
            OleDbDataAdapter dap = new OleDbDataAdapter(comm);
            DataTable ds = new DataTable();
            dap.Fill(ds);
            data1DataGridView.DataSource = ds;
            comm.ExecuteNonQuery();
            conn.Close();
}
