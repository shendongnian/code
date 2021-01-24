    public class MyController : Controller
    {
        private readonly CommoditiesContext comDb;
        private readonly AnotherDbContext anoDb
        public MyController(
                  CommoditiesContext comDb,
                  AnotherDbContext anoDb)
        {
            this.comDb = comDb;
            this.anoDb = anoDb;
        }
    }
