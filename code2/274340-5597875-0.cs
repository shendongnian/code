      SearchResultCollection results = dSearch.FindAll(); 
      if (results.Count == 0)
                throw new Exception("Account not found.");
      else if (results.Count == 1)
            {
                SearchResult result = results[0];
                int userAccountControl = Convert.ToInt32(result.Properties["userAccountControl"][0]);
                string samAccountName = Convert.ToString(result.Properties["samAccountName"][0]);
                bool disabled = ((userAccountControl & 2) > 0);
                if (disabled == false)
                { IsDisabled = false; }
                else { IsDisabled = true; }
            }
      else 
          throw new Exception("More than 1 result found, please filter");
    try
    {
        bool res = dc.DynamicMethod(false, "Username");
    }
    catch (Exception ex)
    {
        if (ex.Message == "Account not found.")
        {
            //Do Something
        }
        else
            throw ex;
    }
