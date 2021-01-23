    CacheDependency rolePathAccessCacheDependency = GetRoleActionRepository().GetRoleActionCacheDependency();
        HttpContext.Current.Cache.Add("anything will do", new object(), rolePathAccessCacheDependency, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal,
                        (key, value, reason) =>
                        {
                            _rolePathAccess = null; 
                        });
