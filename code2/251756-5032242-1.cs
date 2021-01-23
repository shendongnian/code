    public class HomeController : Controller
    {
        private readonly IMilestoneService _service;
        public HomeController(IMilestoneService service)
        {
            _service = service;
        }
    }
