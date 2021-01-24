    public class KlokController : Controller
        {
            KlokContext db = new KlokContext();
    
            List<MyDataModel> modelList = new List<MyDataModel>();
    
            public ActionResult Index()
            {
                // Now you have a List where you put your data from DB
                modelList = db.KLOK.ToList();
    
                return View(modelList);
            }
        }
