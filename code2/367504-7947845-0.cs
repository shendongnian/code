    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }
    
    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute("Book",
            "{productType}/{categoryName}/{productName}/{productId}",
            "~/Books.aspx");
    
        routes.MapPageRoute("Magazine",
            "{productType}/{categoryName}/{productName}/{year}/{month}/{day}/{productId}",
            "~/Magazines.aspx");
    }
