	using Microsoft.Office.Interop.Excel;
	...
	Application app = new Application();
	app.ScreenUpdating = false;
	app.DisplayAlerts = false;
	app.AskToUpdateLinks = false;
	app.Visible = false;
	Workbook workbook = app.Workbooks.Open(fileName + ".html", false, false,
			       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
			       Type.Missing, Type.Missing,
			       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
			       Type.Missing, Type.Missing);
	workbook.SaveAs(fileName + ".csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV);
	workbook.Close(false, Type.Missing, Type.Missing);
	workbook = null;
	app.Quit();
	app = null;
	... 
