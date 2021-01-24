    public static class UtilClass
    {
        [ExcelCommand(Name = "UtilClass.TestMethod")]
        public static void TestMethod()
        {
            // ...
        }
    }
    public class MyAddIn : IExcelAddIn
    {
        public void AutoOpen()
        {
            XlCall.Excel(XlCall.xlcOnKey, "^t", "UtilClass.TestMethod");
        }
        // ...
    }
