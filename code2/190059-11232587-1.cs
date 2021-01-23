    public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                try
                {
                    SPList wpGallery = site.GetCatalog(SPListTemplateType.WebPartCatalog);
                    SPQuery query = new SPQuery();
                    query.Query = “<Where><Eq><FieldRef Name=’FileLeafRef’ /><Value Type=’Text’>webpartname.webpart</Value></Eq></Where>”;
                    SPListItemCollection items = wpGallery.GetItems(query);
                    if (items.Count > 0)
                    {
                        items[0].Delete();
                    }
                }
                catch { }
            }
        }
