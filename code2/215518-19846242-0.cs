    DataTable tableOne = getTableOne();
    DataTable tableTwo = getTableTwo();
    var oneColumns = tableOne.Columns.Cast<DataColumn>()
                                     .Select(p => new Column(p.ColumnName, DataType))
                                     .ToArray();
    var twoColumns = tableTwo.Columns.Cast<DataColumn>()
                                     .Select(p => new DataColumn(p.ColumnName, p.DataType))
                                     .ToArray();
    var matches = (from a in tableOne.AsEnumerable()
                   join b in tableTwo.AsEnumerable() on a["column_name"] equals b["column_name"]
                   select a.ItemArray.Concat(b.ItemArray)).ToArray();
    DataTable merged = new DataTable();
    merged.Columns.AddRange(oneColumns);
    merged.Columns.AddRange(twoColumns);
    foreach (var m in matches) { merged.Rows.Add(m.ToArray()); }
