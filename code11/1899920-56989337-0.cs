    _Application excel = (_Application)Marshal.GetActiveObject("Excel.Application");
    Range range = excel.Cells[1,1];
    range.EntireColumn.NumberFormat = "MM/DD/YYYY hh:mm:ss";
    excel.ActiveWorkbook.SaveAs("test.csv", XlFileFormat.xlCSVWindows);
    excel.ActiveWorkbook.SaveAs("test.txt", XlFileFormat.xlUnicodeText, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges);
