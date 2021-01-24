    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    
    namespace ExcelInterop
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }        
    
            Microsoft.Office.Interop.Excel.Application excelApp;
            Workbook excelWorkBook;
            Worksheet excelWorkSheet;
    
            private void button1_Click(object sender, EventArgs e)
            {
                string path = @"C:\temp\Logfile.CSV";
                int sheetNum = 1;
                string returnValue = string.Empty;
                var missing = Type.Missing;
                int xCell = 1, yCell = 1;
    
                using (AutoReleaseComObject<Microsoft.Office.Interop.Excel.Application> excelRCWWrapper = new AutoReleaseComObject<Microsoft.Office.Interop.Excel.Application>(new Microsoft.Office.Interop.Excel.Application()))
                {
                    var excelApp = excelRCWWrapper.ComObject;
                    var excelAppWkBooks = excelApp.Workbooks;
                    try
                    {
                        using (AutoReleaseComObject<Workbook> excelAppWkBk = new AutoReleaseComObject<Workbook>(excelAppWkBooks.Open(path, false, false, missing, missing, missing, true, missing, missing, true, missing, missing, missing, missing, missing)))
                        {
                            var workbookComObject = excelAppWkBk.ComObject;
                            Worksheet sheetSource = workbookComObject.Sheets[sheetNum];
    
                            using (AutoReleaseComObject< Range> excelAppRange = new AutoReleaseComObject<Range>(sheetSource.UsedRange))
                            {
                                returnValue = excelAppRange.ComObject.Cells[xCell, yCell].Value2.ToString();
                            }
                            ReleaseObject(sheetSource);
                            workbookComObject.Close(false);
                                                }
                    }
                    finally
                    {
                        excelAppWkBooks.Close();
                        ReleaseObject(excelAppWkBooks);
    
                        excelRCWWrapper.ComObject.Application.Quit();
                        excelRCWWrapper.ComObject.Quit();
                        ReleaseObject(excelRCWWrapper.ComObject.Application);
                        ReleaseObject(excelRCWWrapper.ComObject);
    
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                    }
                }
            }
    
            private static void ReleaseObject(object obj)
            {
                try
                {
                    while (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 0) ;
                    obj = null;
                }
                catch (Exception ex)
                {
                    obj = null;
                    Console.WriteLine("Unable to release the Object " + ex.ToString());
                }
            }
    	}
    }
