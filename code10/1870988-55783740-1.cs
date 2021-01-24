    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [EnableQuery(PageSize = 5)]
        public IQueryable<Value> Get()
        {
            return Enumerable.Range(1, 10).Select(i => new Value(i)).AsQueryable();
        }
    }
