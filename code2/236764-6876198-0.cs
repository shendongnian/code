    Microsoft.Office.Interop.Excel.Application oExcelApp;
     
    oExcelApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    foreach (Microsoft.Office.Interop.Excel.Workbook WB in oExcelApp.Workbooks) {
       MessageBox.Show(WB.FullName);
    }
    oExcelApp = null;
