    class Program
    {
        static void Main(string[] args)
        {
            Application excel = null;
            Workbook workbook = null;
            Worksheet workSheet = null;
            object oMissing = Missing.Value;
            excel = new Application { Visible = false };
            workbook = excel.Workbooks.Open(@"c:\Book1.xls", 0, false, 5, "", "",
                       true, XlPlatform.xlWindows, "\t", false, false, 0, true, true, oMissing);
            workSheet = (Worksheet)workbook.Sheets[1];
            try
            {
                string strError = "";
                System.Data.DataTable dtTable = null;
                //If I remove the following line, everything is allright 
                dtTable = ImportDataTableFromExcelIMEX(@"c:\Book1.xls", out strError);
            }
            finally
            {
                if (workSheet != null)
                {
                    Marshal.ReleaseComObject(workSheet);
                    workSheet = null;
                }
                if (workbook != null)
                {
                    workbook.Close(false, oMissing, oMissing);
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (excel != null)
                {
                    excel.Quit();                   
                    Marshal.ReleaseComObject(excel);
                    excel = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
        public static System.Data.DataTable ImportDataTableFromExcelIMEX(string filename, out string error)
        {
            string connstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
         
            try
            {
                using (OleDbConnection upocn = new OleDbConnection(connstring))
                {
                    upocn.Open();
                    System.Data.DataTable dt = null;
                    dt = upocn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    using (OleDbDataAdapter upoda = new OleDbDataAdapter("select * from [" + dt.Rows[0]["TABLE_NAME"].ToString() + "]", upocn))
                    {
                        DataSet upods = new DataSet();
                        error = string.Empty;
                        upoda.Fill(upods);
                        if (!string.IsNullOrEmpty(error))
                            return null;
                        return upods.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
       
            return null;
        }
    }
