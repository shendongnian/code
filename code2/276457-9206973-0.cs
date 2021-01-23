    List<string> lstRemoveColumns = new List<string>() { "ColValue1", "ColVal2", "ColValue3", "ColValue4" };
                    List<DataRow> rowsToDelete = new List<DataRow>();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (lstRemoveColumns.Contains(row["ColumnName"].ToString()))
                        {
                            rowsToDelete.Add(row);
                        }
                    }
                    foreach (DataRow row in rowsToDelete)
                    {
                        dt.Rows.Remove(row);
                    }
                    dt.AcceptChanges();
