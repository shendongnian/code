    try
    {
        //code
    }
    catch (Exception e)
    {
        var lineNumber = new System.Diagnostics.StackTrace(e, true).GetFrame(0).GetFileLineNumber();
    }
