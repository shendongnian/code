    IEnumerable<DataTable> tablesByCategory = 
        table.AsEnumerable().
              GroupBy(r => r.Field<double>("Category")).
              Select(g => 
              {
                  var dt = (DataTable)(table.Clone());
                  foreach (DataRow r in g)
                  {
                      dt.ImportRow(r);
                  }
                  return dt;
              };
