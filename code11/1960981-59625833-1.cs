    using System.Diagnostics;
    using Excel = Microsoft.Office.Interop.Excel;
    void Kill_Excel()
    {
        // Create instance of Excel application.
        // If you don't make Excel window visible, this method WILL NOT work!
        Excel.Application excel = new Excel.Application { Visible = true };
                
        // Catch Excel window handle
        IntPtr hwnd = new IntPtr(excel.Hwnd);
        // Get EXCEL.EXE process
        Process xlproc = Process.GetProcesses().Where(p => p.MainWindowHandle == hwnd).First();
    
        // Do some operations
        Excel.Workbook book = excel.Workbooks.Add();
        Excel.Worksheet sheet = book.Sheets[1] as Excel.Worksheet;
        sheet.Cells[1, 1] = "Hello!";
    
        // Close Excel
        book.Close(SaveChanges: false);
        excel.Quit();
    
        // Garbage collection
        GC.Collect();
        GC.WaitForFullGCComplete();
    
        // Kill process - FOR SURE! :)
        xlproc.Kill();
    }
