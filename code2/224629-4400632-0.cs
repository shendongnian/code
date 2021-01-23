    public static class SafeConvert{
      public static int ParseInt(string val)
      {
        int retval = default;
        try 
        { 
           retval = int.Parse(val); 
        } 
        catch (Exception e) 
        { 
            Trace.WriteLineIf(ConverterSwitch.TraceVerbose, e); 
        } 
            return retval;
     }
  }
