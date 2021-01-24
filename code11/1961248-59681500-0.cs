    Microsoft.Office.Interop.Excel.Application excel = 
        (Microsoft.Office.Interop.Excel.Application)Marshal.GetActiveObject("Excel.Application");
    Workbook wb = (Workbook)excel.ActiveWorkbook;
    for (int i = 1; i < wb.Worksheets.Count; i++)
    {
        MessageBox.Show(wb.Worksheets[i].Name);
    }
