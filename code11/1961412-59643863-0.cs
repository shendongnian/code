 public List<string> GetAllDatasheets()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook = excelApp.Workbooks.Open(filePath);
            var datasheets = new List<string>();
            foreach (Excel.Worksheet sheet in workBook.Worksheets)
            {
                if (sheet.Name.StartsWith("$"))
                    datasheets.Add(sheet.Name);
            }
            excelApp.Quit();
            return datasheets;
        }
If you have the worksheet name you know enough you don't have to make the list with type Worksheet
