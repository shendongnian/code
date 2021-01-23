    private MyContent GetContent(){
       MyContent content = Cache[GetContentCacheKey()];
       if(content == null) {
         content = GetContentFromDb();
         Cache.Add(GetContentCaceKey(), content, null, DateTime.Now.AddHours(24), 
              Cache.NoSlidingExpiration, CacheItemPriority.High, null);
       }
       return content;
    }
