    public Read(string filename)
    {
    	Excel.Application excel = new Excel.Application();
    	Excel.Workbook wb = excel.Workbooks.Open(filename);
    	// Get worksheet names
    	foreach (Excel.Worksheet sh in wb.Worksheets)
    		Debug.WriteLine(sh.Name);
    
    	// Get values from sheets SH1 and SH3 (in my file)
    	object val1 = wb.Sheets["SH1"].Cells[1, "A"].Value2;
    	object val3 = wb.Sheets["SH3"].Cells[1, "A"].Value2;
    	Debug.WriteLine("{0} / {1}", val1, val3);
    
    	wb.Close();
    	excel.Quit();
    }
