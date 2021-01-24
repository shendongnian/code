    var dt = ... // get your data
    var countries = dt.AsEnumerable()
                      .GroupBy(r => new { Country = r.Field<string>("Country") })
                      .Select(g => g.First())
                      .CopyToDataTable();
