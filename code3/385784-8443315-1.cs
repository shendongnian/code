    public static bool SiteExists(string url)
    {
      try
      {
          using (SPSite site = new SPSite(url))
          {
            using (SPWeb web = site.OpenWeb(url, true))
            {
              return true;
            }
          }
      }
      catch (FileNotFoundException)
      {
        return false;
      }
    }
