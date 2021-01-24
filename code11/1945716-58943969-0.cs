    public class ValuesController : ApiController
    {
        DatabaseEntities db;
    
        public ValuesController()
        {
            db = new DatabaseEntities();
        }
    
        public IHttpActionResult GetList()
        {
            return Ok(db.Values.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
