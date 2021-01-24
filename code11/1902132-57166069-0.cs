    [HandleProcessCorruptedStateExceptions]
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
      try
      {
        //Do something...
      }
      catch (Exception ex)
      {
        //This is catching ALL exception types 
        //even AccessViolationException
        //or OutOfMemoryException
      }
    }
