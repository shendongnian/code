    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    Excel.Application excelApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
    Excel.Range target = (Excel.Range)excelApp.get_Caller(System.Type.Missing);
    string cellAddress = target.get_Address(Missing.Value, Missing.Value,
               Excel.XlReferenceStyle.xlA1, Missing.Value, Missing.Value);
