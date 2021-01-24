    public class MyClass
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MyClass(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void MyMethod()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                // do something
            }
        }
    }
