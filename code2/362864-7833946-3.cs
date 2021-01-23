    var rows = tbl.AsEnumerable().Select(row => row).ToList();
    tbl = new DataTable();
    tbl.Columns.Add("ID", typeof(Int32));
    tbl.Columns.Add("NameID", typeof(Int32));
    tbl.Columns.Add("Name", typeof(String));
    
    rows.GroupBy(r => r.Field<int>("NameID"))                
    .Select(rr => rows.First(rw => rw.Field<Int32>("NameID") == rr.Key))
    .ToList().ForEach(rname => tbl.Rows.Add(new object []
        {                                                 
            rname.Field<Int32>("ID"),
            rname.Field<Int32>("NameID"),
            rname.Field<String>("Name"),                    
        }));
