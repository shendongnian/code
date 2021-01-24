     public static DataTable ReadExcelFromPath(string path,int sheetNumber)
        {
            DataTable dt = null;
            try
            {
                //Load the Excel file
                using (Workbook workbook = new Workbook())
                {
                    workbook.LoadFromFile(path);
                    //Get the  worksheet
                    Worksheet sheet = workbook.Worksheets[sheetNumber];
                    //Export data to data table
                    dt = sheet.ExportDataTable();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
