    try
    {
          // var something = e.Result
    }
    catch(Exception ex)
    {
          if (ex.InnerException != null)
          {
               Log.Write(LogTypes.ERROR, "\nInner exception:\n" + ex.InnerException.StackTrace
                                           + "\nex = " + ex.InnerException.Message);
          }
    }
