    var itemGroups = from item in items.Cast<SPListItem>()
                        let siteId = (string) item["siteId"]
                        group item by siteId
                        into siteGroup
                        let siteGroups = from siteItem in siteGroup
                                        let webId = (string) siteItem["webId"]
                                        group siteItem by webId
                                        into webGroup
                                        select new
                                                    {
                                                        WebId = webGroup.Key,
                                                        WebGroups = (from wg in webGroup select wg).ToList()
                                                    }
                        select new
                                {
                                    SiteId = siteGroup.Key,
                                    SiteGroups = siteGroups.ToList()
                                };
