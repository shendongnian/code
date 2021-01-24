    [ApiController]
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public ActionResult Get(string notificationId)
        {
            if (_cache.TryGetValue(notificationId, out _))
                return Ok();
            // Do stuff
            // Store key for one hour
            _cache.Set(notificationId, notificationId, TimeSpan.FromHours(1));
            return Ok();
        }
    }
