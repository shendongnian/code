    public static void SetValue(string dictionaryName, string key, string value)
    {
      if (!String.IsNullOrEmpty(key))
      {
        try
        {
            if (HttpContext.Current.Session[dictionaryName] != null)
            {
                Dictionary<string, string> form = (Dictionary<string, string>)HttpContext.Current.Session[dictionaryName];
                if (form.ContainsKey(key))
                {
                    form[key] = value;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error("{0}: Error while checking Session value from Dictionary", ex, "SessionDictionary");
        }
      }
    }
