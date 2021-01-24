    public class CustomService
    {
        private IHttpContextAccessor httpContextAccessor;
    
        public CustomService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
    
        public void CustomMethod()
        {
            var userId = this.httpContextAccessor.GetUserId();
            // do what you want with user identifier
        }
    }
