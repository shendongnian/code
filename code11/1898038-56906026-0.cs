    public override void ItemAdded(SPItemEventProperties properties)
    {
        LoLogInfo("event@receiver@ starting!");
        SPSecurity.RunWithElevatedPrivileges(delegate ()
        {
            LogInfo("event@receiver@ first step!");
            using (SPSite site = new SPSite(properties.SiteId))
            {
                LogInfo("event@receiver@ second step!");
                using (SPWeb web = site.OpenWeb(properties.Web.ID))
                {
                    LogInfo("event@receiver@ third step!");
                    SPList activeList = web.Lists.TryGetList(properties.List.Title);
                    SPList finalList = web.Lists[FinalListName];
                    web.AllowUnsafeUpdates = true;
                    SPListItem finalListItem = finalList.AddItem();
                    LogInfo("event@receiver@ forth step!");
    		        //some other code here
                    web.AllowUnsafeUpdates = false;
                    }
             }                
        });
    }
