    DataTable table = new DataTable();
    var results = from row in table.AsEnumerable()
                  group row by new { Type = row.Field<int>("Type") } into groups
                  select new
                  {
                      Type = groups.Key.Type,
                      TotalValue = groups.Sum(x => x.Field<int>("Value"))
                  };
