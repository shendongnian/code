        private const string VendorNotificationCacheKey = "VendorNotification";
    
        protected void Application_Start(object sender, EventArgs e)
        {
        //Set value in cache with expiration time
        CacheItemRemovedCallback callback = OnRemove;
        //Expire after 15 minutes
        Context.Cache.Add(VendorNotificationCacheKey, DateTime.Now, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero,
                            CacheItemPriority.Normal, callback);
        }
        private void OnRemove(string key, object value, CacheItemRemovedReason reason)
        {
            SendVendorNotification();
            //Need Access to HTTPContext so cache can be re-added, so let's call a page. Application_BeginRequest will re-add the cache.
            var siteUrl = ConfigurationManager.AppSettings.Get("SiteUrl");
            var client = new WebClient();
            client.DownloadData(siteUrl + "default.aspx");
            client.Dispose();
        }
        private void SendVendorNotification()
        {
            //Do Tasks here
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Re-add if it doesn't exist
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("default.aspx") &&
                HttpContext.Current.Cache[VendorNotificationCacheKey] == null)
            {
                //ReAdd
                CacheItemRemovedCallback callback = OnRemove;
                Context.Cache.Add(VendorNotificationCacheKey, DateTime.Now, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero,
                                  CacheItemPriority.Normal, callback);
            }
        }
