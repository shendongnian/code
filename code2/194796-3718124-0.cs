    using System.Data.OleDb;
    OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;User Id=;Password=;Data Source=" + fileName);
    conn.Open();
    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query_txt.Text, conn);
    DataSet ds = new DataSet();
    dataAdapter.Fill(ds);
    dataGridView.DataSource = ds.tables[0];
    conn.Close();
