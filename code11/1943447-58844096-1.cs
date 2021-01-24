    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductStatus model = new ProductStatus();
            List<ProductStatus> statusList = (List<ProductStatus>)Session["ProductStatuses"];
            if (statusList != null)
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
