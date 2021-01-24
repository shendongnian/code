    public class ValuesController : ApiController
    {
            readonly IDatabaseEntities _db;
    
            //here db is being provided to the ctor by your
            //DI Library e.g. StructureMap, SimpleInjector, .Net Core Injection, etc.
            public ValuesController(IDatabaseEntities db)
            {
                _db = db; //null check left out for brevity
            }
    
            public IHttpActionResult GetList()
            {
                return Ok(_db.Values.ToList());
            }
    }
