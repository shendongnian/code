    SPSecurity.RunWithElevatedPrivileges(delegate ()
    {
        using (SPSite site = new SPSite(properties.SiteId))
        {
            using (SPWeb web = site.OpenWeb(properties.Web.ID))
            {
                web.AllowUnsafeUpdates = true;
                SPList someList = web.Lists.tryGetList("LISTNAME");
                SPListItem newItem = someList.AddItem();
                // .... update columns and newItem.Update()
                web.AllowUnsafeUpdates = false;
            }
        }
    }
