    public static string GetResMsg(this HtmlHelper htmlHelper, string key)
    {
      try
      {
        return Resources.[resource class name].ResourceManager.GetString(key);
      }
      catch
      {
        return "?";
      }
    }
