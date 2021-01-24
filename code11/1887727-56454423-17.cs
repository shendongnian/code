            //ensure unique named columns in b, and grow a's columns
            foreach (DataColumn bcol in b.Columns) {
                while (a.Columns.Contains(bcol.ColumnName))
                    bcol.ColumnName += "_";
                a.Columns.Add(bcol.ColumnName, bcol.DataType);
            }
            //perform left join
            foreach (DataRow aro in a.Rows) {
                var f = b.Rows.Find(aro["ID"]);
                if (f != null)
                    foreach (DataColumn bcol in b.Columns)
                        aro[bcol.ColumnName] = f[bcol];
            }
