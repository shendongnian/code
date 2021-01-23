        /// <summary>
        /// Sets the DynamicSiteMapProviders.ThisNode property to the node of specified URL.
        /// </summary>
        /// <param name="urlOfNodeToSetTo">The URL of the node to set from.</param>
        public static void SetThisNodeToAlternateNode(string urlOfNodeToSetTo)
        {
            SiteMapDataSource siteMapDataSource = new SiteMapDataSource();
            siteMapDataSource.SiteMapProvider = "Main";
            DynamicSiteMapProviders.ThisNode = siteMapDataSource.Provider.FindSiteMapNode(urlOfNodeToSetTo);
        }
