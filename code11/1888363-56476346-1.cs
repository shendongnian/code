    DataTable _dt = new DataTable();
    _dt.Columns.Add("DateTime", typeof(string));
    _dt.Columns.Add("VALUE1", typeof(double));
    _dt.Columns.Add("VALUE2", typeof(double));
    
    
    DataTable result = dt.AsEnumerable()
         .Select(x =>
         {
             var r = _dt.NewRow();
    
             r["DateTime"] = Convert.ToString(x["Date"]) + ", " + Convert.ToString(x["Time"]);
             r["VALUE1"] = Convert.ToDouble(x["VALUE1"]);
             r["VALUE2"] = Convert.ToDouble(x["VALUE2"]);
    
             return r;
         })
         .CopyToDataTable();
