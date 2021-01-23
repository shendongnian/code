    SPSecurity.RunWithElevatedPrivileges(delegate() {
        SPWeb _web = properties.Feature.Parent as SPWeb; 
        SPUserToken sysAdmin = _web.Site.SystemAccount.UserToken;
        using (SPSite elevatedSite = new SPSite(_web.Site.ID, sysAdmin)) {
            using (SPWeb web = elevatedSite.OpenWeb(_web.ID)) {
                //Code goes here...
            }
        }
    });
