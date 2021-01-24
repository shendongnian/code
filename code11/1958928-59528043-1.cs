    public class Test 
    {
        public void Main()
        {
           IExcelDoc excelDoc = GetDocType();
           excelDoc.ExportToExcel();
        }
        private IExcelDoc GetDocType()
        {
         if(...)
            return new ExcelDoc1();
         else
            return new ExcelDoc2();
        }
    }
