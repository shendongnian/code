    foreach (DataTable table in ds.Tables)
    {
        GridView gv = new GridView();
        gv.DataSource = table;
        gvPlaceHolder.Controls.Add(gv);
    }
    
