    DataTable dt = new DataTable();
    List<dynamic> dns = new List<dynamic>();
    foreach (var item in dt.AsEnumerable())
    {
        dynamic dn = new ExpandoObject();
        foreach (var column in dt.Columns.Cast<DataColumn>())
        {
            dn[column.ColumnName] = item[column];
        }
        dns.Add(dn);
    }
