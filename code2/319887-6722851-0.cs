    void AddSheet()
    {
     OpenFileDialog excelSheetToOpen = new OpenFileDialog();
                excelSheetToOpen.Filter = "Excel 97- 2003 WorkBook (*.xls)| *.xls | Excel 2007 WorkBook (*.xlsx) | *.xlsx | All files (*.*)|*.*";
                excelSheetToOpen.FilterIndex = 3;
                excelSheetToOpen.Multiselect = false;
    
                 Excel.Worksheet ws = Globals.ThisWorkbook.Worksheets.get_Item("RunningParameters");
    
    
                 if (excelSheetToOpen.ShowDialog() == DialogResult.OK)
                 {
    
                     Excel.Application excelApp = new Excel.Application();
                     String workbookPath = excelSheetToOpen.FileName;
                     Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath);
                     Excel.Sheets excelWorkBookSheets = excelWorkbook.Sheets;
    
                     Excel.Range _UsedRangeOftheWorkSheet;
                     
    
                     foreach (Excel.Worksheet _Sheet in excelWorkBookSheets)
                     {
                         if (_Sheet.Name == ws.get_Range("B3").Value)
                         {
                             _Sheet.UsedRange.Copy();
                             _UsedRangeOftheWorkSheet = _Sheet.UsedRange;
    
                             Object [,] s = _UsedRangeOftheWorkSheet.Value;                        
                           
                             
                             Excel.Worksheet _WorkingSheet = Globals.ThisWorkbook.Sheets.Add(ws);
                             _WorkingSheet.Name = "WorkingSheet";
                             _WorkingSheet.Paste();
                            
                             
                             
                         }
                     }  
    
                 }
    
    
    }
