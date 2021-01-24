                var count1 = Enumerable.Range(0, dt.Columns.Count)
                    .Select(x => new { column = x, count = dt.AsEnumerable().Where(row => row[x] != DBNull.Value).Count() })
                    .ToList();
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Column Name", typeof(string));
                dt2.Columns.Add("Count", typeof(int));
                foreach (var count in count1)
                {
                    dt2.Rows.Add(new object[] { dt.Columns[count.column].ColumnName, count.count }); 
                }
