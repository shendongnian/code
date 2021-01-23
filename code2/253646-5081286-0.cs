    // site and web objects working with the current user's privileges
    SPSite userSite = SPContext.Current.Site;
    SPWeb userWeb = SPContext.Current.Web;
    
    // elevate privileges
    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
        // get new site and web objects working with elevated privileges
        using (SPSite elevatedSite = new SPSite(userSite.ID)) 
        {
            using (SPWeb elevatedWeb = ElevatedsiteColl.OpenWeb(userWeb.ID)) 
            {
                // …code using elevatedSite and elevatedWeb…
            }
        }
    });
