    public static IQueryable<Something> PressuresJoin(ObjectContext rc)
    {
        return from b in rc.Pressures
            join g in rc.GUIDIdentityMaps on b.UserIdentity equals g.UserIdentity;
    }
        
