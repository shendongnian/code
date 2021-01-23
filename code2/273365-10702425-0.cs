    private DataRow SelectRoW()
        {
            DataRow[] objDataRows = null;
           
                if (gridView1 == null || gridView1.SelectedRowsCount == 0)
                { return null; }//end if
                else
                {
                    objDataRows = new DataRow[gridView1.SelectedRowsCount];
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        objDataRows[i] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                    }//end for
                    gridView1.BeginSort();
                    try
                    {
                        foreach (DataRow row in objDataRows)
                        {
                            return row;//return selected row.
                        }//end foreach
                    }//end try
                    finally
                    {
                        objDataRows = null;
                        gridView1.EndSort();
                    }//end finally
                }//end else
          
            return null;
        }//end SelectRoW
