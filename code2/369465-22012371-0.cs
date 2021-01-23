                        DataRow dr = dt.Rows[selectedIndex];
                        ArrayList drList = new ArrayList();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            drList.Add(dr[i]);
                        }
                        dt.Rows[selectedIndex].Delete();
                        dt.AcceptChanges();
                        DataRow drNew = dt.NewRow();
                        for (int i = 0; i < drList.Count; i++)
                        {
                            drNew[i] = drList[i];
                        }
                        drList = null;
                        dt.Rows.InsertAt(drNew, (selectedIndex));
                        dt.AcceptChanges();
