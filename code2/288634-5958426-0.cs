	public void RunMeFirst()
	{
		System.Type oSEType = Type.GetTypeFromProgID("Excel.Application");
		xlsApp = Activator.CreateInstance(oSEType);
		Workbook xlsWb = xlsApp.Workbooks.Open("C:\\test1.xls");
		// Do stuff
		xlsWb.Close(false);
		
		System.Environment.Exit(0);
	}
