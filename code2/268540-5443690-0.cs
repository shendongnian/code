    public void Debug( string message )
    {
      message = string.Format( "{0}: {1}", GetCallingMethodInfo(), message );
      // logging stuff
    }
    
    /// <summary>
    /// Gets the application name and method that called the logger.
    /// </summary>
    /// <returns></returns>
    private static string GetCallingMethodInfo()
    {
      // we should be looking at the stack 2 frames in the past:
      // 1. for the calling method in this class
      // 2. for the calling method that called the method in this class
      MethodBase method = new StackFrame( 2 ).GetMethod();
      string name = method.Name;
      string type = method.DeclaringType.Name;
      
      return string.Format( "{0}.{1}", type, name );
    }
