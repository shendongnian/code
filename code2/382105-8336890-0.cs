    public class CachePlanExtension //does not have to be static
    {
        public static CacheSettings GetPlan(this CachePlan cachePlan, ControllerContext filterContext) //has to be static!
        {
            //the cachePlan-Parameter will later contain the CachePlan-object, on which you call this method. Example:
            var name = cachePlan.Name;
            
            
            CacheSettings ca = new CacheSettings();
            ca.IsCachingEnabled = true;
            ca.Duration = 100;
            return ca;
        }
    }
