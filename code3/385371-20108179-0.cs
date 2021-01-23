    using(SPSite site = new SPSite("http://my.dev.com"))
    {
        using(SPWeb web = site.OpenWeb())
        {
            SPFile page = web.GetFile("SitePages/Welcome.aspx");
            using(SPLimitedWebPartManager manager = page.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                string errMsg = string.Empty;
                SPFile myWebPart = web.GetFile("_catalogs/wp/myWebPart.webpart");
                XmlTextReader read = newXmlReader(myWebPart.OpenBinaryStream());
                var wp = manager.ImportWebPart(read, out errMsg);
                manager.AddWebPart(wp, "<Webpart Zone>", 1);
                manager.SaveChanges(wp);
            }  
        }
    }
