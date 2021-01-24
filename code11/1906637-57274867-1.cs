    FileInfo fi = new FileInfo(ExcelFilesPath + "myExcelFile.xlsx");
    
    using (ExcelPackage pck = new ExcelPackage())
    {
        // Using Existing WorkSheet 1.
        ExcelWorksheet ws = pck.Workbook.Worksheets[1];
    
        // Loading Data From DataTable Called dt.
        ws.Cells["A1"].LoadFromDataTable(dt, true);
    
        // If you want to enable auto filter
        ws.Cells[ws.Dimension.Address].AutoFilter = true;
    
        // Some Formatting
        Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#00B388");
        ws.Cells[ws.Dimension.Address].Style.Fill.PatternType = ExcelFillStyle.Solid;
        ws.Cells[ws.Dimension.Address].Style.Fill.BackgroundColor.SetColor(colFromHex);
        ws.Cells[ws.Dimension.Address].Style.Font.Color.SetColor(Color.White);
        ws.Cells[ws.Dimension.Address].Style.Font.Bold = true;
        ws.Cells["D:K"].Style.Numberformat.Format = "0";
        ws.Cells["M:N"].Style.Numberformat.Format = "mm-dd-yyyy hh:mm:ss";
        ws.Cells[ws.Dimension.Address].AutoFitColumns();
        
        pck.SaveAs(fi);
        
    }
