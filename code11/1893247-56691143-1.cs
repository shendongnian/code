    public class NotificationController : ApiController
    {
        IHubContext context;
        public NotificationController()
        {
            context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        }
    
        public HttpResponseMessage Get(string message)
        {
            object[] args = { message };
            context.Clients.All.Send("Send", args) ;
    
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
