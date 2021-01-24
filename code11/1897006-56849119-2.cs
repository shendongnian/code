    public class MyService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MyService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SetSomeSessionValue(string value)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            httpContext.Session["example"] = value;
        }
    }
