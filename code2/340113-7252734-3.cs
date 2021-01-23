                DragEventHandler dds = (sdd, edd) =>
                {
                    var dr = edd.Data.GetData(typeof(DataRow)) as DataRow;
                    if (dr != null)
                    {
                        var dst = dataTable;
                        var src = dr.Table;
                        if (dst != src)
                        {
                            dst.ImportRow(dr);
                            dr.Delete();
                            src.AcceptChanges();
                            dst.AcceptChanges();
                        }
                    }
                };
