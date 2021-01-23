                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 0)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        foreach (DataColumn dc in dt.Columns)
                        {
                            dc.DataType = typeof(String);
                        }
                    }
                    DataRow dr = ds.Tables[0].NewRow();
                    for (int i = 0; i < dr.ItemArray.Count(); i++)
                    {
                        dr[i] = string.Empty;
                    }
                    ds.Tables[0].Rows.Add(dr);
                }
