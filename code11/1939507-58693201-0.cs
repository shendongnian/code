    public class Database1Controller : ODataController
    {
        private Database1Context Context = new Database1Context();
        [EnableQuery]
        [ODataRoute(DB1Entity1.ApiSubUrl, RouteName = "Database1")]
        public IQueryable<DB1Entity1> GetEntity1()
        {
            return Context.Entity1.AsQueryable();
        }
        [EnableQuery]
        [ODataRoute(DB1Entity2.ApiSubUrl, RouteName = "Database1")]
        public IQueryable<DB1Entity2> GetEntity2()
        {
            return Context.Entity2.AsQueryable();
        }
    }   
