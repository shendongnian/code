    DataTable tvp = new DataTable();
    tvp.Columns.Add(new DataColumn("OptionID", typeof(int)));
    tvp.Columns.Add(new DataColumn("ValueID", typeof(int)));
    
    foreach (<OptionValue>x in o.OptionValueLst) {
    DataRow dr = tvp.NewRow();
    dr("OptionID") = x.OptionID;
    dr("ValueID") = x.ValueID; 
    tvp.Rows.Add(dr); 
    }
