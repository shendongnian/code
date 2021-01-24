    public class MyController : Controller
    {
        private readonly CommoditiesContext db;
        public MyController(CommoditiesContext db)
        {
            // db is 'automatically' created and given to you.
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var list = (from commodity in db.Commodity
                        where commodity.DateObsolete.Equals(null)
                        select commodity.Name.Trim().ToUpper()).OrderBy(a => a).ToList();
            return this.Ok(list);
        }
    }
