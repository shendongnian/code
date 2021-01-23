        private void processExcel(string filename)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            var missing = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filename, false, true, missing, missing, missing, true, Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            Array myValues = (Array)xlRange.Cells.Value2;
            int vertical = myValues.GetLength(0);
            int horizontal = myValues.GetLength(1);
            DataTable dt = new DataTable();
            // must start with index = 1
            // get header information
            try
            {
                for (int i = 1; i <= horizontal; i++)
                {
                    dt.Columns.Add(new DataColumn(Convert.ToString(myValues.GetValue(1, i))));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            // Get the row information
            for (int a = 2; a <= vertical; a++)
            {
                object[] rows = new object[horizontal];
                for (int b = 1; b <= horizontal; b++)
                {
                    rows[b - 1] = myValues.GetValue(a, b);
                }
                DataRow row = dt.NewRow();
                row.ItemArray = rows;
                dt.Rows.Add(row);
            }
            // assign table to default data grid view
            dataGridView1.DataSource = dt;
            xlWorkBook.Close(true, missing, missing);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
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
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
