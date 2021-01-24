               DataTable dt = new DataTable();
                int numberColumns = dt.Columns.Count;
                foreach(DataRow row in dt.AsEnumerable())
                {
                    if(row["HSN Code"] == string.Empty)
                    {
                        row["HSN Code"] = string.Join(",", row.ItemArray.Skip(1).Select(x => x.ToString()));
                        for (int i = 1; i < numberColumns; i++)
                        {
                            row[i] = DBNull.Value;
                        }
                    }
                }
