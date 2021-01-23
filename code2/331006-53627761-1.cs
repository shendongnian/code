                using (var tbl = new DataTable())
                using (var rdr = cmd.ExecuteReader())
                {
                    tbl.BeginLoadData();
                    try
                    {
                        tbl.Load(rdr);
                    }
                    catch (ConstraintException ex)
                    {
                        rdr.Close();
                        tbl.Clear();
                        // clear constraints, source of exceptions
                        // note: column schema already loaded!
                        tbl.Constraints.Clear();
                        tbl.Load(cmd.ExecuteReader());
                    }
                    finally
                    {
                        tbl.EndLoadData();
                    }
                }
