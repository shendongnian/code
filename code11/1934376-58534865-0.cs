    ExcelEngine excelEngine = new ExcelEngine();
    IApplication application = excelEngine.Excel;
    application.UseFastRecordParsing = true;
    var stream = await graphClient.Me.Drive.Root.ItemWithPath("Sample.xlsx").Content.Request().GetAsync();
    stream.Position = 0;
    MemoryStream file = new MemoryStream();
    stream.CopyTo(file);
    file.Position = 0;
    IWorkbook workbook = await application.Workbooks.OpenAsync(file);
