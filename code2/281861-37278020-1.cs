                   int a = grdvw.PageIndex;
                   int rowcount=0;
                    for (int i = 0; i < grdvw.PageCount; i++)
                    {
                        grdvw.SetPageIndex(i);
                        foreach (GridViewRow row in grdvw.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                              rowcount++;
                            }
                        }
                   }
                 grdvw.SetPageIndex(a);
