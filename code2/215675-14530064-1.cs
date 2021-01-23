    for (int i = 0; i < ds.Tables.Count; i++)
    {
               GridView gv = new GridView();
                gv.DataSource = ds.Tables[i];
                gvPlaceHolder.Controls.Add(gv);
    }
