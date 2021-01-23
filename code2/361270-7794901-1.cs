    var dt = new DataTable();
    var dns = new List<dynamic>();
    foreach (var item in dt.AsEnumerable())
    {
        // Expando objects are IDictionary<string, object>
        IDictionary<string, object> dn = new ExpandoObject();
        foreach (var column in dt.Columns.Cast<DataColumn>())
        {
            dn[column.ColumnName] = item[column];
        }
        dns.Add(dn);
    }
    // Now you can do something like dns[0].MyColumnName 
    // or recast to IDictionary<string, object> and do 
    // something like casted["MyColumnName"]
