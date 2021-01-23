    // Actual Code
    DataColumn col = dt.Columns[0]; // Call this the one you have
    DataTable tbl = col.Table;
    var first = tbl.AsEnumerable()
                   .Select(cols => cols.Field<DateTime>(col.ColumnName))
                   .OrderBy(p => p.Ticks)
                   .FirstOrDefault();
    var last = tbl.AsEnumerable()
                  .Select(cols => cols.Field<DateTime>(col.ColumnName))
                  .OrderByDescending(p => p.Ticks)
                  .FirstOrDefault();
