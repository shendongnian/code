    public class HomeController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;
    
        public HomeController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
    }
    
    public async Task<IActionResult> Index()
    {
        await _hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");
        return View();
    }
