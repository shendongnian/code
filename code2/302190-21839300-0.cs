    public static void MoveWorksheet()
    {
    public static Excel.Application oXL;
    public static Excel._Worksheet ws;
    if (File.Exists(Global.Variables.GlobalVariables.recap))
    {
    //workbookToOpen is location and name
	oXL.Workbooks.Open(workbookToOpen, Missing.Value, true);
	object ws = null;
	try
	{
		ws = wb.Sheets["Sheet 1"];
		if (ws != null)
		{
			((Worksheet)ws).UsedRange.Interior.ColorIndex = Constants.xlNone;
			((Worksheet)ws).Copy();
			oXL.ActiveWorkbook.SaveAs("SaveAsFileName" + ".xlsx");
			oXL.ActiveWorkbook.Close(true);
		}
	}
	catch {}
    }
    }
