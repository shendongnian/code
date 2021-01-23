    public static void RemoveValue(string dictionaryName, string key)
    {
      if (!String.IsNullOrEmpty(key))
      {
        try
        {
            if (HttpContext.Current.Session[dictionaryName] != null)
            {
                Dictionary<string, string> form = (Dictionary<string, string>)HttpContext.Current.Session[dictionaryName];
                form.Remove(key); // no error if key didn't exist
            }
        }
        catch (Exception ex)
        {
            Logger.Error("{0}: Error while checking Session value from Dictionary", ex, "SessionDictionary");
        }
      }
    }
