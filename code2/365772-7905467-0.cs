            if (someCondition) 
            {
                System.Web.HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.Public); //Location="Any"
                System.Web.HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(1800)); //Duration="1800"
                System.Web.HttpContext.Current.Response.Cache.SetValidUntilExpires(true); //VaryByParam="None"
            }
