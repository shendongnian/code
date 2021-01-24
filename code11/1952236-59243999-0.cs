    var workbook = ExcelFile.Load("input.xls");
    var worksheet = workbook.Worksheets.ActiveWorksheet;
    
    worksheet.NamedRanges.SetPrintArea(
        worksheet.GetUsedCellRange(true));
    
    var options = new PdfSaveOptions();
    options.SelectionType = SelectionType.ActiveSheet;
    workbook.Save("output.pdf", options);
