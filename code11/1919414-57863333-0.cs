        public class RouteManagement
        {
            public List<Routes> Routes { get; set; }
        }
        public class Routes
        {
            public string Endpoint { get; set; }
            public Routes.DestinationManagement Destination { get; set; }
            public class DestinationManagement
            {
                public DestinationManagement()
                {
                    Uri = "/";
                    RequiresAuthentication = false;
                }
                public string Uri { get; set; }
                public bool RequiresAuthentication { get; set; }
            }
        }
