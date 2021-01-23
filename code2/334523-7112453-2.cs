    DataTable dt = GetDataTableResults();
    
    var results = from row in dt.AsEnumerable()
                  group row by new { SomeIDColumn = row.Field<int>("SomeIDColumn") } into rowgroup
                  select new
                  {
                      SomeID = rowgroup.Key.SomeIDColumn,
                      SomeTotal = rowgroup.Sum(r => r.Field<decimal>("SomeDecimalColumn"))
                  };                    
    DataTable queryResults = new DataTable();
    foreach (var result in query)
        queryResults.Rows.Add(new object[] { result.SomeID, result.SomeTotal });
