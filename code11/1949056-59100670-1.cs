    public class Program
    {
        public static void Main(string[] args)
        {
            ExcelPackage dpcExcel = new ExcelPackage();
            var searchWord = "myExcel";
            //Method 1
            //Will contain an ExcelWorkSheet or null
            var sheet = FindExcelSheetV1(dpcExcel, searchWord);
            //Method 2
            //Will contain an ExcelWorkSheet or we need to handle the exception
            var sheet2 = new ExcelWorksheet();
            try
            {
                sheet2 = FindExcelSheetV2(dpcExcel, searchWord);
            }
            catch (Exception e)
            {
                //Do something
                Console.WriteLine(e.Message);
                throw;
            }
            //Method 3
            //Will contain an ExcelWorkSheet or null
            var sheet3 = dpcExcel.FindExcelSheetV3(searchWord);
        }
        //Will return null if not found, or if any class or property is null
        private static ExcelWorksheet FindExcelSheetV1(ExcelPackage dpcExcel, string v)
        {
            try
            {
                var sheet = dpcExcel.Workbook.Worksheets.FirstOrDefault(w => w.Name.Equals(v));
                return sheet;
            }
            catch
            {
                return null;
            }
        }
        //This will throw an ArgumentNullException if any class or property is null
        private static ExcelWorksheet FindExcelSheetV2(ExcelPackage dpcExcel, string v)
        {
            var sheet = dpcExcel.Workbook.Worksheets.FirstOrDefault(w => w.Name.Equals(v));
            return sheet;
        }
    }
    public static class ExcelPackageExtensions
    {
        // Like FindExcelSheetV1, but in an extension method. 
        public static ExcelWorksheet FindExcelSheetV3(this ExcelPackage dpcExcel, string v)
        {
            try
            {
                var sheet = dpcExcel.Workbook.Worksheets.FirstOrDefault(w => w.Name.Equals(v));
                return sheet;
            }
            catch
            {
                return null;
            }
        }
    }
