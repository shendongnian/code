    [HttpPost] public IActionResult Excel () {
                using (ExcelEngine excelEngine = new ExcelEngine ()) {
                    //Instantiate the Excel application object
                    IApplication application = excelEngine.Excel;
    
                    //Assigns default application version
                    application.DefaultVersion = ExcelVersion.Excel2013;
    
                    //A new workbook is created equivalent to creating a new workbook in Excel
                    //Create a workbook with 1 worksheet
                    IWorkbook workbook = application.Workbooks.Create (1);
    
                    //Access a worksheet from workbook
                    IWorksheet worksheet = workbook.Worksheets[0];
    
                    //Adding text data
                    worksheet.Range["A1"].Text = "Month";
                    worksheet.Range["B1"].Text = "Sales";
                    worksheet.Range["A6"].Text = "Total";
    
                    //Adding DateTime data
                    worksheet.Range["A2"].DateTime = new DateTime (2015, 1, 10);
                    worksheet.Range["A3"].DateTime = new DateTime (2015, 2, 10);
                    worksheet.Range["A4"].DateTime = new DateTime (2015, 3, 10);
    
                    //Applying number format for date value cells A2 to A4
                    worksheet.Range["A2:A4"].NumberFormat = "mmmm, yyyy";
    
                    //Auto-size the first column to fit the content
                    worksheet.AutofitColumn (1);
    
                    //Adding numeric data
                    worksheet.Range["B2"].Number = 68878;
                    worksheet.Range["B3"].Number = 71550;
                    worksheet.Range["B4"].Number = 72808;
    
                    //Adding formula
                    worksheet.Range["B6"].Formula = "SUM(B2:B4)";
                    var name = Guid.NewGuid () + ".xlsx";
                    // FileStream inputStream = new FileStream (name, FileMode.Create, FileAccess.ReadWrite);
                    string ContentType = "Application/msexcel";
                    MemoryStream outputStream = new MemoryStream ();
                    workbook.SaveAs (outputStream);
                    outputStream.Position = 0;
                    return File (outputStream, ContentType, name);
                }
    
            }
