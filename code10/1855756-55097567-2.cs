    List<DataTable> tablesByCategory = 
        table.AsEnumerable().
              GroupBy(r => r.Field<double>("Category")).
              Select(g => 
              {
                  DataTable dt = table.Clone();
                  foreach (DataRow r in g)
                  {
                      dt.ImportRow(r);
                  }
                  return dt;
              }).ToList();
