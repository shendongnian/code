        public class HomeController : Controller
            {
                public ActionResult Index()
                { 
                    Database db = DatabaseFactory.CreateDatabase();
                    DbCommand dbCommand = db.GetStoredProcCommand("spGetSomething");
                    DbCommand cmd = new ProfiledDbCommand(dbCommand, dbCommand.Connection, MiniProfiler.Current);
                    DataSet ds = db.ExecuteDataSet(cmd);
        			...
