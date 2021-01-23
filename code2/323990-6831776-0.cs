     DataTable mytable;
     String key = "key"
     if(HttpContext.Current.Cache[Key] ==null)
     {
            mytable = GetDTFromDB();
            if(mytable.Rows.Count > 0)
                HttpContext.Current.Cache.Insert(strKey, mytable, Nothing, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
        else
            mytable = HttpContext.Current.Cache[strKey];
      }
