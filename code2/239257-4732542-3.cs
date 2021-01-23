    //Creating dummy datatable for testing
    DataTable dt = new DataTable();
    DataColumn dc = new DataColumn("col1", typeof(DateTime));
    dt.Columns.Add(dc);
    dc = new DataColumn("col2", typeof(DateTime));
    dt.Columns.Add(dc);
    dc = new DataColumn("col3", typeof(DateTime));
    dt.Columns.Add(dc);
    dc = new DataColumn("col4", typeof(DateTime));
    dt.Columns.Add(dc);
    DataRow dr = dt.NewRow();
    dr[0] = "coldata1";
    dr[1] = "coldata2";
    dr[2] = "coldata3";
    dr[3] = "coldata4";
    dt.Rows.Add(dr);//this will add the row at the end of the datatable
    //OR
    int yourPosition = 0;
    dt.Rows.InsertAt(dr, yourPosition);
