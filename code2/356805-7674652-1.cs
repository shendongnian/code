    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.ApplicationClass excel = new Excel.ApplicationClass();
    Excel.Application app = excel.Application;
    Excel.Range all = app.get_Range("A1:H10", Type.Missing);
