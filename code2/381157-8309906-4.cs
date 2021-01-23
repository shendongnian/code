    {
      SPWeb spWeb = spSite.OpenWeb();
      try
      {
    
        // Some Code
      }
      finally
      {
        if (spWeb != null)
        {
           spWeb.Dispose();
        }
      }
    }
