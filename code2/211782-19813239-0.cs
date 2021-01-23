                    DataTable dt = new DataTable();
                    dt = sdr.GetSchemaTable();
                    dt.Constraints.Clear();
                    dt.BeginLoadData();
                    dt.Load(sdr);
                    //dt.EndLoadData(); // Enables constraints again
