    DataTable dt=new DataTable();
    dt.Columns.Add("Column2");
    dt.Columns.Add("Column1");
    DataRow dr=dt.NewRow();
    dr["Column2"]="";
    dr["Column1"]="";
    dt.Rows.Add(dr);
    yourDatagrid.DataSource=dt;
    YourDatagrid.DataBind();
