    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductStatus model = new ProductStatus();
            ViewData["Status"] = statusList;
            return View(model);
        }
        public ActionResult SendMessages(ProductStatus status) 
        {
            List<ProductStatus> statuses = (List<ProductStatus>)Session["ProductStatuses"];
            if (statuses == null)
            {
                 statuses = new List<ProductStatus>();
                 Session["ProductStatuses"] = statuses;
            }
            statusList.Add(status);
            ViewData["Status"] = statusList;
            return View("Index");
        }
    }
