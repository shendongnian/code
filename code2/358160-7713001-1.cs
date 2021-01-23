    class PressuresGUIDIdentityMap
    {
        public Pressure Pressure;
        public GUIDIdentityMap GUIDIdentityMap;
    }
    public static IQueryable<PressuresGUIDIdentityMap> PressuresJoin(ObjectContext rc)
    {
        return from b in rc.Pressures
            join g in rc.GUIDIdentityMaps on b.UserIdentity equals g.UserIdentity
            select new PressuresGUIDIdentityMap { Pressure = b, GUIDIdentityMap = g };
    }
        
