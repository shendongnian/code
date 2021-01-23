    DataTable dt = new DataTable("MyDataTable");
    DataColumn dc = new DataColumn("DateColumn");
    dc.DataType = typeof(DateTime);
    dt.Columns.Add(dc);
    for (int i = 0; i <= 5; i++)
    {
        DataRow newRow = dt.NewRow();
        newRow[0] = DateTime.Now.AddDays(i);
        dt.Rows.Add(newRow);
    }
    DateTime maxDate =  
        Convert.ToDateTime(
                            ((from DataRow dr in dt.Rows
                              orderby Convert.ToDateTime(dr["DateColumn"]) descending
                              select dr).FirstOrDefault()["DateColumn"]
                              )
                            );
    DateTime minDate = 
        Convert.ToDateTime(
                            ((from DataRow dr in dt.Rows
                              orderby Convert.ToDateTime(dr["DateColumn"]) ascending
                              select dr).FirstOrDefault()["DateColumn"]
                              )
                            );
