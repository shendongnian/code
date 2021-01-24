    public class AddIn : IExcelAddIn
    {
        public void AutoOpen()
        {
            ExcelRegistration
                .GetExcelFunctions()
                .ProcessParamsRegistrations()
                .RegisterFunctions();
            // ...
        }
    
        public void AutoClose()
        {
            // ...
        }
    }
