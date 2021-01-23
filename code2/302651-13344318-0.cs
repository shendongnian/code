      public DataTable GetContentAsDataTable(bool IgnoreHideColumns=false)
            {
                try
                {
                    if (dgv.ColumnCount == 0) return null;
                    DataTable dtSource = new DataTable();
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (IgnoreHideColumns & !col.Visible) continue;
                        if (col.Name == string.Empty) continue;
                        dtSource.Columns.Add(col.Name, col.ValueType);
                        dtSource.Columns[col.Name].Caption = col.HeaderText;
                    }
                    if (dtSource.Columns.Count == 0) return null;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        DataRow drNewRow = dtSource.NewRow();
                        foreach (DataColumn  col in dtSource .Columns)
                        {
                            drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                        }
                        dtSource.Rows.Add(drNewRow);
                    }
                    return dtSource;
                }
                catch { return null; }
            }
