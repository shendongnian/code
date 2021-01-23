        private int GetLastRow()
        {
            Excel.Application ExcelApp;
            ExcelApp = new Excel.Application();
            ExcelApp.Selection.End(Excel.XlDirection.xlDown).Select();
            ExcelApp.Selection.End(Excel.XlDirection.xlDown).Select();
            ExcelApp.Selection.End(Excel.XlDirection.xlDown).Select();
            ExcelApp.Selection.End(Excel.XlDirection.xlUp).Select();
            return ExcelApp.ActiveCell.Row;
        }
