            var app = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
            var wb = app.ActiveWorkbook;
            var ws = wb.Worksheets[1] as Excel.Worksheet;
            var cells = ws.Cells;
            var match = cells.Find("apples", LookAt:=Excel.XlLookAt.xlPart) as Excel.Range;
            var matchAdd = match != null ? match.Address : null;
