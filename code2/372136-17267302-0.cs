            Excel.Application xl = null;
            Excel._Workbook wb = null;
            xl = new Excel.Application();
            xl.SheetsInNewWorkbook   = 1;
            xl.Visible   = true;
            wb = (_Workbook)(xl.Workbooks.Add(Missing.Value));
