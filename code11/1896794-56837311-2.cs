    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }
    /// Many other events like begin request...e.t.c
    void RegisterRoutes(RouteCollection routes)
    {
        //Example: https://my.syte.com/updatedns/qft
        routes.MapPageRoute("updateDNS", "public/updateDNS/{hostname}",
                "~/pages/public/updateDNS.aspx"
                , false
            );
    }
}
~~~~
