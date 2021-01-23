    DataTable Dt = new DataTable();
    Dt.Columns.Add("Name");
    Dt.Columns.Add("Age");
    
    Dt.Rows.Add(new object[] { "Babar", 44 });
    Dt.Rows.Add(new object[] { "Babul", 55 });
    Dt.Rows.Add(new object[] { "Bahar", 66 });
    Dt.Rows.Add(new object[] { "Baird", 3 });
    Dt.Rows.Add(new object[] { "Cable", 77 });
    
    // Linq option
    var q = from r in Dt.AsEnumerable()
        where r.Field<int>("Age") > 50
        select r;
    
    DataRow[] LinkFoundRows = q.ToArray<DataRow>();
    
    // Lambda expression option (one liner)
    DataRow[] FoundRows2 = Dt.AsEnumerable().Where(row => row.Field<int>("Age") > 50).ToArray<DataRow>();
    DataRow[] StdSelect = Dt.Select("Age > 50");
    
    // all three requests will result you DataRows containing Babar, Bahar, Cable
