    public bool SomeMethod(ref string Error)
    {
      bool result = false;
      try
      {
        if (...)
        {
            return result;
        }
        else
        {
            result = true;
            ...
            return result;
        }
    }
    finally
    {
        if (!result)
        {
                LogAMessage("");
                ...
                Error = "...";
                ...
        }
    }
