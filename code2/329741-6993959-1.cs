    private static void Main(string[] args)
    {
    	string FileName = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "Book2.xlsx");
    
    	Application excelApp = new Application();
    	Workbooks excelWorkbooks = excelApp.Workbooks;
    	Workbook report = excelWorkbooks.Open(FileName, 0, false, 5, "", "", true, XlPlatform.xlWindows, "", true, false, 0, false, false, false);
    
    	var y = report.Names.Item("M_Leitung").RefersToRange.Value;
    
    	Console.WriteLine(y);
    	excelWorkbooks.Close();
    	excelApp.Quit();
    }
