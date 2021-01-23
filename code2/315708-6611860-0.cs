     //Create Instance of CacheManager 
     ICacheManager _objCacheManager = CacheFactory.GetCacheManager();
     
     AbsoluteTime timeToExpire = new AbsoluteTime(TimeSpan.FromMinutes(60));
            MyData myData = null;
            myData = (MyData)cacheManager.GetData("ref");
            if (myData == null)
            {
                //get the data
                cacheManager.Add("ref", myData, CacheItemPriority.Normal, null, timeToExpire);
            }
            return myData;
