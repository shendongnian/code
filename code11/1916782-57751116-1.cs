    public class HomeController : Controller
    {
        private readonly HubConnection Connection;
        public HomeController(HubConnection connection)
        {
            Connection = connection;
        }
    }
