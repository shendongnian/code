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
     public static List<DataTable> ReadAllExcelSheetFromPath(string path)
        {
            List<DataTable> dt_list = new List<DataTable>();
            try
            {
                //Load the Excel file
                using (Workbook workbook = new Workbook())
                {
                    workbook.LoadFromFile(path);
                    for (int i = 0; i < workbook.Worksheets.Count; i++)
                    { //Get the first worksheet
                        Worksheet sheet = workbook.Worksheets[i];
                        //Export data to data table
                        dt_list.Add( sheet.ExportDataTable());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt_list;
        }
