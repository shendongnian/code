    public class AdminController : Controller
    {
        private readonly IAdminMenuService lmService;
        public IAdminMenuService testService;
        public AdminController(IAdminMenuService layoutMarkupService)
        {
            this.lmService = layoutMarkupService;
            testService = lmService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult menuPartial()
        {
            return PartialView("_AdminMenuPartial", new adminMenuVM(testService));
        }
