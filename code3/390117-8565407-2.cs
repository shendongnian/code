    static void Main() {
        var excel = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.WorksheetFunction wsf = excel.WorksheetFunction;
        var start = new DateTime(1999, 11, 1);
        var end = new DateTime(1999, 1, 11);
        for (var basis = 0; basis != 5; basis++) {
            Console.WriteLine(wsf.YearFrac(start, end, basis));
        }
    }
