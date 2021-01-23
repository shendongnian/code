    public static class Container
    {
        private static Dictionary<int, Shuttle> shuttles;
        private static Dictionary<int, Route> routes;
        /* Other stuff goes on to initialize shuttles and routes I  assume */
        public static List<Route> getRoutes(string stopId)
        {
            List<Route> stopRoutes = new List<Route>();
            foreach (int myKey in routes.Keys)
            {
                 foreach (string str in routes[myKey].stops.Keys)
                 {
                       if (routes[myKey].stops[str] == stopId)
                       {
                            stopRoutes.Add(routes[myKey]);
                            break;
                       }
                 }
             }
             
             return stopRoutes;
          }
