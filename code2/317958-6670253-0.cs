    DataTable dt = new DataTable;
    ...  
    
    ds2 = db2.ExecuteDataSet(command2);
    for(int i = 0; i < ds2.Tables[0].Rows.Count; i ++)
    dt.ImportRow(ds2.Tables[0].Rows[i]);
    
    ...
    DataGrid1.DataSource = dt;
    DataGrid1.DataBind();
