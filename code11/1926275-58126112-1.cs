    public class MyController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
    
        public MyController(IHttpContextAccessor httpContextAccessor)
        {
          _httpContextAccessor = httpContextAccessor;            
        }
    
        [HttpPost]
        [Authorize]
        public JsonResult CreateOrder([FromBody] OrderModel model)
        {
          string username = Helper.GetUserName(_httpContextAccessor);
          .....
        }
    }
