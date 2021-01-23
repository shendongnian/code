            var web = site.RootWeb;
            
            web.MasterUrl = web.CustomMasterUrl = SPUtility.ConcatUrls(web.ServerRelativeUrl, "_catalogs/mymaster.master");
            web.Update();
            foreach (SPWeb subWeb in site.AllWebs)
            {
                using (subWeb)
                {
                    if (subWeb.IsRootWeb) continue;
                    var hash = subWeb.AllProperties;
                    subWeb.MasterUrl = subWeb.CustomMasterUrl = web.MasterUrl;
                    hash["__InheritsMasterUrl"] = "True";
                    hash["__InheritsCustomMasterUrl"] = "True";
                    subWeb.Update();
                }
            }
