    using (IDataReader reader = ExecuteReader(sql))
                {
                    DataTable dt = new DataTable();
                    using (DataSet ds = new DataSet() { EnforceConstraints = false })
                    {
                        ds.Tables.Add(dt);
                        dt.Load(reader, LoadOption.OverwriteChanges);
                        ds.Tables.Remove(dt);
                    }
                    return dt;
                }
