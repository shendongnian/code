    public static class MyClass
    {
    
      // not recomended:
      int static GetParams(ref thisObject, object Param1, object Params, object Param99)
      {
        int ErrorCode = 0;
        
        try
        {
          ...
        }
        catch (System.DivideByZeroException dbz)
        {
          ErrorCode = ...;
          return ErrorCode;
        }
        catch (AnotherException dbz)
        {
          ErrorCode = ...;
          return ErrorCode;
        }
        return ErrorCode;
      } // method
    
      // recomended:
      int static Get(ref thisObject, object ParamsGroup)
      {
        int ErrorCode = 0;
        
        try
        {
          ...
        }
        catch (System.DivideByZeroException dbz)
        {
          ErrorCode = ...;
          return ErrorCode;
        }
        catch (AnotherException dbz)
        {
          ErrorCode = ...;
          return ErrorCode;
        }
        
        return ErrorCode;
      } // method
    
    } // class
Its similar to your tuple result. Cheers.
