    SqlCeDataAdapter da = new SqlCeDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    
    da.SelectCommand = new SqlCommand(@"SELECT * FROM FooTable", connString);
    da.Fill(ds, "FooTable");
    dt = ds.Tables["FooTable"];
    
    foreach (DataRow dr in dt.Rows)
    {
        MessageBox.Show(dr["Column1"].ToString());
    }
