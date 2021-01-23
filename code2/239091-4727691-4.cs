    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public ActionResult Search(ProductViewModel product)
        {
            var equipmentsResults = EquipmentQueries.GetEquipments(product);
            return View(equipmentsResults);
        }
    }
