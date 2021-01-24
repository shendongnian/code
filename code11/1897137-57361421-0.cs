    ExcelAsyncUtil.QueueAsMacro(state =>
    {
    	try
    	{
    		app.ScreenUpdating = (bool)state;
    	}
    	catch (Exception e)
    	{
    		e.LogExceptionError($"ExcelAsyncUtil.QueueAsMacro");
    	}
    }, enable); // enable can be true or false.
