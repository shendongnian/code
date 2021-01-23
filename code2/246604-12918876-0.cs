            DataTable dtCloned = dt.Clone();
            foreach (DataColumn dc in dtCloned.Columns)
                dc.DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }
            foreach (DataRow row in dtCloned.Rows)
            {
                for (int i = 0; i < dtCloned.Columns.Count; i++)
                {
                    dtCloned.Columns[i].ReadOnly = false;
                    if (string.IsNullOrEmpty(row[i].ToString()))
                        row[i] = string.Empty;
                }
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dtCloned);
            string xml = ds.GetXml();
