    public class ExcelFile
    {
        private Application _excelApp;
        private readonly Workbook _workbook;
        private Range _range;
        private ExcelFile(string path)
        {
            _excelApp = new Application();
            _workbook = _excelApp.Workbooks.Open(path);
        }
        private void CloseFile()
        {
            _workbook.Close(0);
            _excelApp.Quit();
            _excelApp.Dispose();
        }
    }
