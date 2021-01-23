    var results = dt1.AsEnumerable().Join(dt2.AsEnumerable(),
                        a => a.Field<String>("Location"),
                        b => b.Field<String>("Location"),
                        (a, b) =>
                        {
                            DataRow row = table.NewRow();
                            row.ItemArray = a.ItemArray.Concat(b.ItemArray).ToArray();
                            table.Rows.Add(row);
                            return row;
                        });
