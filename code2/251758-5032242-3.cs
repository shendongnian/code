    public class HomeController : Controller
    {
        private readonly IMilestoneService _service;
        public HomeController(IMilestoneService service)
        {
            _service = service;
            Enforce.NotNull(() => _service); // lambda to auto-magically get variable name for exception
        }
    }
