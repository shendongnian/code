    private static void RethrowExceptionButPreserveStackTrace(Exception exception)
    {
        System.Reflection.MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace",
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        preserveStackTrace.Invoke(exception, null);
          throw exception;
    }
