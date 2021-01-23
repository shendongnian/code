                MouseEventHandler mds = (smd, emd) =>
                {
                    var info = grid.HitTest(emd.X, emd.Y);
                    if (info.RowIndex >= 0)
                    {
                        var dr = dataTable.Rows[info.RowIndex];
                        if (dr != null)
                        {
                            grid.DoDragDrop(dr, DragDropEffects.Copy);
                        }
                    }
                };
