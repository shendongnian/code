       public static void UrlRouting(RouteCollection RC, string RoutName, string routeUrl, string Page)
        {
            RC.MapPageRoute(RoutName, routeUrl, Page);
        }
    after this inside Application_Start event on global.ascx file 
    call that function like 
    UrlRouting(RouteTable.Routes, "index", "Home", "~/index.aspx");
