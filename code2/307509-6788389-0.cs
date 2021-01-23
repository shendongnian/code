    using (SPWeb w = ((SPSite)properties.Feature.Parent).OpenWeb())
            {
                Uri masterUri = new Uri(w.Url + "/_catalogs/masterpage/AdventureWorks.master");
                w.CustomMasterUrl = masterUri.AbsolutePath;
                w.AllowUnsafeUpdates = true;
                w.Update();
                foreach (SPWeb ww in w.Site.AllWebs)
                {
                    if (!ww.IsRootWeb)
                    {
                        Hashtable hash = ww.AllProperties;
                        if (string.Compare(hash["__InheritsCustomMasterUrl"].ToString(), "True", true) == 0)
                        {
                            ww.CustomMasterUrl = masterUri.AbsolutePath;
                            ww.AllowUnsafeUpdates = true;
                            ww.Update();
                        }
                    }
                }
            }
