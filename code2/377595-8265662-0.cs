    GridView1.DataSource = ds.Tables[0];
    GridView1.DataBind();
    if (ds.Tables[0].Rows.Count > 0)
    {
         int numberOfColumn = ds.Tables[0].Columns.Count;
         if (numberOfColumn >= 5) // Since the 5th column you want to unwrap
         GridView1.Columns[5].ItemStyle.Wrap = false;
     }
