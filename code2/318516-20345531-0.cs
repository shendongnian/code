    Excel.Application excelApp = null;
    Excel.Workbooks wkbks = null;
    Excel.Workbook wkbk = null;
    bool wasFoundRunning = false;
    Excel.Application tApp = null;
    //Checks to see if excel is opened
    try
    {
    	tApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    	wasFoundRunning = true;
    }
    catch (Exception)//Excel not open
    {
    	wasFoundRunning = false;
    }
    finally
    {
    	if (true == wasFoundRunning)
    	{
    		excelApp = tApp;
    		wkbk = excelApp.Workbooks.Add(Type.Missing);                    
    	}
    	else
    	{
    		excelApp = new Excel.Application();
    		wkbks = excelApp.Workbooks;
    		wkbk = wkbks.Add(Type.Missing);
    	}
    	//Release the temp if in use
    	if (null != tApp) { Marshal.FinalReleaseComObject(tApp); }
    	tApp = null;
    }
    //Initialize the sheets in the new workbook
