    public ActionResult Import(HttpPostedFileBase upload)
    {
        var users = new List<User>();
        var excelPackage = new ExcelPackage(upload.InputStream);
        // Reading the first worksheet
        var worksheet = excelPackage.Workbook.Worksheets[1];
        // Number of rows and columns
        int totalRows = worksheet.Dimension.Rows;
        int totalCols = expectedHeaders.Count();
        
        for (int row = 1; row <= totalRows; row++)
        {
            // Filling variables or creating objects
            var Name = worksheet.Cells[row, 1].Text;
    ...
        }
    ...
    }
    
