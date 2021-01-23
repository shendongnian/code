    private static void PreserveStackTrace(Exception exception)
    {
      MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace",
        BindingFlags.Instance | BindingFlags.NonPublic);
      preserveStackTrace.Invoke(exception, null);
    }
    
    ...
    catch (Exception ex)
    {
      // do something
      // ...
      PreserveStackTrace(ex);
      throw;
    }
 
