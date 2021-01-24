    public static  void csvToXls(string source, string destination, string fileName)
    {
        string csvFileName = source;
        string excelFileName = destination + "/" + fileName + ".xls";
        string worksheetsName = "sheet 1";
              
        using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFileName)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
            var text = File.ReadAllText(source);
            var rows = text.Split('\n');
                
            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var excelRow = worksheet.Row(rowIndex+1);
                var columns = rows[rowIndex].Split('|');
                for (int colIndex = 0; colIndex < columns.Length; colIndex++)
                {
                    worksheet.Cells[rowIndex +1, colIndex +1].Value = columns[colIndex];
                }
            }
            package.Save();
        }
    }
