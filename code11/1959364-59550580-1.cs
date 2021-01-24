        public class TestController : Controller
      {
        private readonly EndpointDataSource _endpointDataSource;
        public TestController ( EndpointDataSource endpointDataSource)
        {
            _endpointDataSource = endpointDataSource;
        }
        
        public IActionResult Index()
        {
            string url = "https://localhost/User/Account/Logout";
            // Return a collection of Microsoft.AspNetCore.Http.Endpoint instances.
            var routeEndpoints = _endpointDataSource?.Endpoints.Cast<RouteEndpoint>();
            var routeValues = new RouteValueDictionary();
            string LocalPath = new Uri(url).LocalPath;
            //To get the matchedEndpoint of the provide url
            var matchedEndpoint = routeEndpoints.Where(e => new TemplateMatcher(
                                                                        TemplateParser.Parse(e.RoutePattern.RawText),
                                                                        new RouteValueDictionary())
                                                                .TryMatch(LocalPath, routeValues))
                                                .OrderBy(c => c.Order)
                                                .FirstOrDefault();
            if (matchedEndpoint != null)
            {
                string area = routeValues["area"]?.ToString();
                string controller = routeValues["controller"]?.ToString();
                string action = routeValues["action"]?.ToString();
            }
            return View();
        }
       }
