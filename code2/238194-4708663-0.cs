    private void getSites()
    {
       SPSite oSiteCollection = SPContext.Current.Site;
       SPWebCollection collWebsite = oSiteCollection.AllWebs;
          for (int i = 0; i < collWebsite.Count; i++)
       {
           ddlParentSite.Items.Add(new ListItem(collWebsite[i].Title, collWebsite[i].Id));
       }
       // oSiteCollection.Dispose(); // NEVER DISPOSE THE SPContext.Current.Site or Web
    }
    using( var site = SPContext.GetContext(HttpContext.Current).Site)
    {
      using(var parentWeb = site.OpenWeb(new Guid(DDLVALUE))
      {
        newWeb = parentWeb.Webs.Add(newSiteUrl, newSiteName, null, (uint)1033, siteTemplate, true, false);
        try
        {
          newWeb.Update();
        }
      }
    }
