    List<string> list = ...
    DataTable table = ...
    
    var items = new HashSet<string>(list);
    var results = from row in table.AsEnumerable()
                  where items.Contains(row.Field<string>("YourColumnName"))
                  select row;
    
    foreach (var matchingRow in results)
    {
        // do whatever
    }
