    using (SPSite site = new SPSite(siteUrl))
    {
        using (SPWeb web = site.OpenWeb())
        {
            SPList list = web.Lists[listName];
            SPListItem item = list.Items[0];
    
            SPFieldLookupValueCollection spflvc = new SPFieldLookupValueCollection();
            spflvc.Add(new SPFieldLookupValue(3, string.Empty));
            spflvc.Add(new SPFieldLookupValue(7, string.Empty));
            item["Keywords"] = spflvc;
            item.Update();
        }
    }
