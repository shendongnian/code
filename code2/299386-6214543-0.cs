    using (OleDbConnection con = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\hms.mdb"))
    {
        con.Open();
        string sql = "select * from login";
        using (OleDbDataAdapter da = new OleDbDataAdapter(sql, con))
        {
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dRow = ds.Tables[0].NewRow();
            dRow[1] = "sakest";
            ds.Tables["hms"].Rows.Add(dRow);
            da.Fill(ds, "hms");
            da.Update(ds, "hms");
            MessageBox.Show("new enrtry ");
        }
    }
