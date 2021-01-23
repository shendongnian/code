    public DataSet Dtl()
            {
                //Instance reference for Excel Application
                Microsoft.Office.Interop.Excel.Application objXL = null;        
                //Workbook refrence
                Microsoft.Office.Interop.Excel.Workbook objWB = null;
                DataSet ds = new DataSet();
                try
                {
                    objXL = new Microsoft.Office.Interop.Excel.Application();
                    objWB = objXL.Workbooks.Open(@"Book1.xlsx");//Your path to excel file.
                    foreach (Microsoft.Office.Interop.Excel.Worksheet objSHT in objWB.Worksheets)
                    {
                        int rows = objSHT.UsedRange.Rows.Count;
                        int cols = objSHT.UsedRange.Columns.Count;
                        DataTable dt = new DataTable();
                        int noofrow = 1;
                        //If 1st Row Contains unique Headers for datatable include this part else remove it
                        //Start
                        for (int c = 1; c <= cols; c++)
                        {
                            string colname = objSHT.Cells[1, c].Text;
                            dt.Columns.Add(colname);
                            noofrow = 2;
                        }
                        //END
                        for (int r = noofrow; r <= rows; r++)
                        {
                            DataRow dr = dt.NewRow();
                            for (int c = 1; c <= cols; c++)
                            {
                                dr[c - 1] = objSHT.Cells[r, c].Text;
                            }
                            dt.Rows.Add(dr);
                        }
                       ds.Tables.Add(dt);
                    }
                    //Closing workbook
                    objWB.Close();
                    //Closing excel application
                    objXL.Quit();
                    return ds;
                }
    
                catch (Exception ex)
                {
                   objWB.Saved = true;
                    //Closing work book
                    objWB.Close();
                    //Closing excel application
                    objXL.Quit();
                    //Response.Write("Illegal permission");
                    return ds;
                }
            }
