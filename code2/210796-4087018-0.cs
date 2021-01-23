        protected void Application_EndRequest()
        {
            if (HttpContext.Current.Items["ISCACHED"] == null)
            {
                var cache = HttpContext.Current.Response.Cache;
                cache.SetCacheability(HttpCacheability.NoCache);
                cache.SetNoStore();
                cache.SetExpires(DateTime.Now.AddDays(-1));
            }
        }
