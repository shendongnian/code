    using Excel = Microsoft.Office.Interop.Excel;
    public Excel.Application xlApp;
    public Excel.Workbook xlWorkBook;
    public Excel.Worksheet xlWorkSheet;
    public void ExcelTransferData()
    {
       xlApp = new Microsoft.Office.Interop.Excel.Application();
       xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
       foreach (Excel.Workbook item in xlApp.Workbooks)
       {
            //Select the excel target 'NAME'
            if (item.Name == "Template.xlsx")
            {
                xlWorkBook = item; 
                break;
            }
            //Select the target workbook
            xlWorkSheet = xlWorkBook.Sheets[1] as Excel.Worksheet;
            //Set cell value
            xlWorkSheet.Cells[5, 1] = "davinceleecode";
       }
    }
