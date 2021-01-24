                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.DataType == typeof(DateTime))
                        {
                            stdTable.Rows.Add(new object[] { col.ColumnName, DateTime.Parse(row[col].ToString()).ToString("dd/MM/yyyy HH:mm:ss") });
                        }
                        else
                        {
                            stdTable.Rows.Add(new object[] { col.ColumnName, row[col].ToString() });
                        }
                    }
