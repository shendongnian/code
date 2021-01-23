    using Excel = Microsoft.Office.Interop.Excel;
...
    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
        Excel.Application app;
        Excel.Workbook workbook;
    
        app = new Excel.ApplicationClass();
        app.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
    
        workbook = app.Workbooks.Open(  openFileDialog.FileName,
                                        0,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing,
                                        Type.Missing);
    
        return workbook;
    }
