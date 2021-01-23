    Application excel = new Application();
    Workbook wb = excel.Workbooks.Open(destPath);
    Worksheet ws = wb.Worksheets[1];
 
    bool wasProtected = ws.ProtectContents;
    if (wasProtected == true)
    {
        // unprotect the worksheet
    }
    else
    {
        ws.Cells[row, clmn].Interior.Color = XlRgbColor.rgbBlack;
    }
    ...
    if (wasProtected == true)
    {
        // protect back the worksheet
    }
