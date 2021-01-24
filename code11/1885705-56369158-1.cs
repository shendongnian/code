    [...]
    
    public ObservableCollection<Lecturer> Lecturers { get; set; }
    public MyViewModel()
    {
      Lecturers = new ObservableCollection<Lecturer>();
    }
    public void ExtractLecturersFromXlFile(string filePath)
    {
     Excel.Application xlApp = new Excel.Application();
     Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
     Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
    
     Excel.Range range = sheet.UsedRange;
     Excel.Range excelrange = (Excel.Range)sheet.get_Range("A1:C100",Type.Missing);
     // Iterate through datas, fill Lecturer's object and add it to the Observable                 
     // Collection
     // Cleanup  
     GC.Collect();
     GC.WaitForPendingFinalizers();
  
     Marshal.ReleaseComObject(xlWorksheet);
     // Close and release  
     xlWorkbook.Close();
     Marshal.ReleaseComObject(xlWorkbook);
     // Quit and release  
     xlApp.Quit();
     Marshal.ReleaseComObject(xlApp);
    }
