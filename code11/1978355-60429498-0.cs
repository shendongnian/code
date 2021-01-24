    public class RequestHandler
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        public RequestHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor; 
        }
        public void HandleIndexRequest()
        {
            // do something for the request  
            var message = "This is a much cleaner approach to access Session!";
            this.HttpContextAccessor.HttpContext.Session.Set<string>("message", message);
        }
    }
