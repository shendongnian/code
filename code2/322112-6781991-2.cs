    public static class MyClass
    {
    
      // not recomended:
      int static GetParams(ref thisObject, object Param1, object Params, object Param99)
      {
        const int ERROR_NONE = 0;
        
        try
        {
          ...
        }
        catch (System.DivideByZeroException dbz)
        {
          ERROR_NONE = ...;
          return ERROR_NONE;
        }
        catch (AnotherException dbz)
        {
          ERROR_NONE = ...;
          return ERROR_NONE;
        }
        return ERROR_NONE;
      } // method
    
      // recomended:
      int static Get(ref thisObject, object ParamsGroup)
      {
        const int ERROR_NONE = 0;
        
        try
        {
          ...
        }
        catch (System.DivideByZeroException dbz)
        {
          ERROR_NONE = ...;
          return ERROR_NONE;
        }
        catch (AnotherException dbz)
        {
          ErrorCode = ...;
          return ERROR_NONE;
        }
        
        return ERROR_NONE;
      } // method
    
    } // class
Its similar to your tuple result. Cheers.
