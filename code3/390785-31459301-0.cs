        SqlConnection cnn;
            string connectionstring = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;
           
            ////*** Preparing excel Application
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            ///*** Opening Excel application
          
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\MM18100\Documents\Visual Studio 2013\Projects\SQL\SQL\Book1.csv");
            xlWorkSheet = (Excel.Worksheet)(xlWorkBook.ActiveSheet as Excel.Worksheet);
            ////*** It will always remove the prvious result from the CSV file so that we can get always the updated data
            xlWorkSheet.UsedRange.Select();
            xlWorkSheet.UsedRange.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
            xlApp.DisplayAlerts = false;
            //xlWorkBook.Save();
            /////***Opening SQL Database
            connectionstring = "Integrated Security = SSPI;Initial Catalog=Exascale; Data Source=DCNA-Q-SQL-07;";
            cnn = new SqlConnection(connectionstring);
            cnn.Open();
            ////** Write your Sql Query here
            sql = "SELECT  TOP 10 [FirstName],[MiddleName],[LastName],[Email],[AltEmail],[Phone],[AltPhoneNumber],[Mobile],[Fax],[CompanyName],[AuthorizedUserName],[AuthorizedUserPhone],[CreatedDate],[ModifiedDate],[VERSION],[LanguageID],[TaxID],[CustomerType]FROM [Exascale].[dbo].[Customer] Where [FirstName] = 'Automation'";
            ///*** Preparing to retrieve value from the database
            SQL.DataTable dtable = new SQL.DataTable();
          
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            SQL.DataSet ds = new SQL.DataSet();
            dscmd.Fill(dtable);
            ////*** Generating the column Names here
            string[] colNames = new string[dtable.Columns.Count];
            int col = 0;
            foreach (SQL.DataColumn dc in dtable.Columns)
                colNames[col++] = dc.ColumnName;
            char lastColumn = (char)(65 + dtable.Columns.Count - 1);
            xlWorkSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
            xlWorkSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
            xlWorkSheet.get_Range("A1", lastColumn + "1").VerticalAlignment
                        = Excel.XlVAlign.xlVAlignCenter;
            
            /////*** Inserting the Column and Values into Excel file
            
            for (i = 0 ; i <= dtable.Rows.Count - 1; i++)
                {
                    for (j = 0; j <= dtable.Columns.Count-1; j++)
                      {
                              data = dtable.Rows[i].ItemArray[j].ToString();
                              xlWorkSheet.Cells[i + 2, j + 1] = data;
                          
                    }
                }
            ///**Saving the csv file without notification.
                xlApp.DisplayAlerts = false;
                xlWorkBook.Save();
                //xlWorkBook.SaveAs("Book1.csv", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                
          
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            ////MessageBox.Show("Excel file created , you can find the file C:\\Users\\MM18100\\Documents\\informations.xls");
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
