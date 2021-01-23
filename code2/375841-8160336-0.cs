    public static void AddItemElevated(SPListItem itemToAdd, string listName)
    {  
      SPWeb web = SPContext.Current.Web;
        
        SPSecurity.RunWithElevatedPrivileges(delegate()
        {
            using (SPSite elevatedSite = new SPSite(web.Url))
            {
                using (SPWeb elevatedWeb = elevatedSite.OpenWeb())
                {
                    elevatedWeb.AllowUnsafeUpdates = true;
                    SPList list = elevatedWeb.Lists[listName];
                    SPListItem item = list.Items.Add();
                    item = itemToAdd;
                    item.Update();
                    elevatedWeb.AllowUnsafeUpdates = false;
                }
            }
        }
    }
