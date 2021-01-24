    public class RoleController : Controller
    {
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;
    
        public RoleController(IMvcControllerDiscovery mvcControllerDiscovery)
        {
            _mvcControllerDiscovery = mvcControllerDiscovery;
        }
    
        // GET: Role/Create
        public ActionResult Create()
        {
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();
    
            return View();
        }
    } 
