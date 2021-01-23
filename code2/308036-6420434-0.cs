    DataSet1 DataSet1 = new DataSet1();
    DataTable dt = DataSet1.Tables(0);
    DataColumn dc = null;
    
    foreach (DataColumn dc_loopVariable in dt.Columns) {
    	dc = dc_loopVariable;
    	Response.write(dc.ColumnName.ToString() + " " + dc.DataType.ToString() + "<br>");
    }
