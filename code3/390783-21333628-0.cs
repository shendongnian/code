    public class ExportToExcel
    {
        string strCon = ConfigurationManager.ConnectionStrings["SafewayGVDemoDBContext"].ConnectionString;
        private Microsoft.Office.Interop.Excel.Application app;
        private Microsoft.Office.Interop.Excel.Workbook workbook;
        private Microsoft.Office.Interop.Excel.Worksheet previousWorksheet;
        // private Excel.Range workSheet_range;
        private string folder;
        public ExportToExcel(string folder)
        {
            this.folder = folder;
            this.app = null;
            this.workbook = null;
            this.previousWorksheet = null;
            // this.workSheet_range = null;
            createDoc();
        }
        private void createDoc()
        {
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                workbook = app.Workbooks.Add(1);
            }
            catch (Exception excThrown)
            {
                throw new Exception(excThrown.Message);
            }
            finally
            {
            }
        }
        public void shutDown()
        {
            try
            {
                workbook = null;
                app.Quit();
            }
            catch (Exception excThrown)
            {
                throw new Exception(excThrown.Message);
            }
            finally
            {
            }
        }
        public void ExportTable(string procName, string sheetName)
        {
            SqlDataReader myReader = null;
            try
            {
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets.Add(Missing.Value, Missing.Value, 1, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                using (SqlConnection Sqlcon = new SqlConnection(strCon))
                {
                    SqlCommand cmd = new SqlCommand();
                    Sqlcon.Open();
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Parameters.Add(new SqlParameter("@pvchAction", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add("@pIntErrDescOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters["@pvchAction"].Value = "select";
                    worksheet.Name = sheetName;
                    previousWorksheet = worksheet;
                    myReader = cmd.ExecuteReader();
                    int columnCount = myReader.FieldCount;
                    for (int n = 0; n < columnCount; n++)
                    {
                        //Console.Write(myReader.GetName(n) + "\t");
                        createHeaders(worksheet, 1, n + 1, myReader.GetName(n));
                    }
                    int rowCounter = 2;
                    while (myReader.Read())
                    {
                        for (int n = 0; n < columnCount; n++)
                        {
                            //Console.WriteLine();
                            //Console.Write(myReader[myReader.GetName(n)].ToString() + "\t");
                            addData(worksheet, rowCounter, n + 1, myReader[myReader.GetName(n)].ToString());
                        }
                        rowCounter++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                myReader = null;
            }
        }
        public void createHeaders(Microsoft.Office.Interop.Excel.Worksheet worksheet, int row, int col, string htext)
        {
            worksheet.Cells[row, col] = htext;
        }
        public void addData(Microsoft.Office.Interop.Excel.Worksheet worksheet, int row, int col, string data)
        {
            worksheet.Cells[row, col] = data;
        }
        public void SaveWorkbook()
        {
            String folderPath = @"C:\My Files\" + this.folder;
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            string fileNameBase = "db";
            String fileName = fileNameBase;
            string ext = ".xlsx";
            int counter = 1;
            //System.IO.File.Open(folderPath + fileName + ext, System.IO.FileMode.Open);
            while (System.IO.File.Exists(folderPath + @"\"+ fileName + ext))
            {
                fileName = fileNameBase + counter;
                counter++;
            }
            fileName = fileName + ext;
            string filePath = folderPath +@"\"+ fileName;
            try
            {
                workbook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
