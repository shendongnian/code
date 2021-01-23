    try
    {
    	Globals.ThisAddIn.Application.ScreenUpdating = false;
    	...
    }
    ...
    finally
    {
    	Globals.ThisAddIn.Application.ScreenUpdating = true;
    }
