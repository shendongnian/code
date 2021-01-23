    var testNamespace = new RouteValueDictionary();
                testNamespace.Add("namespaces", new HashSet<string>(new string[] 
                { 
                    "MySite.Controllers.Framed"
                }));
    
                //for some reason we need to delare the empty version to support /framed when it does not have a controller or action
                routes.Add("FramedEmpty", new Route("Framed", new MvcRouteHandler())
                {
                    Defaults = new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Index",
                        id = UrlParameter.Optional
                    }),
                    DataTokens = testNamespace
                });
    
                routes.Add("FramedDefault", new Route("Framed/{controller}/{action}/{id}", new MvcRouteHandler())
                {
                    Defaults = new RouteValueDictionary(new
                    {
                        //controller = "Home",
                        action = "Index",
                        id = UrlParameter.Optional
                    }),
                    DataTokens = testNamespace
                });
    var defaultNamespace = new RouteValueDictionary();
                defaultNamespace.Add("namespaces", new HashSet<string>(new string[] 
                { 
                    "MySite.Controllers"
                }));
    
    routes.Add("Default", new Route("{controller}/{action}/{id}", new MvcRouteHandler())
                    {
                        Defaults = new RouteValueDictionary(new
                        {
                            controller = "Home",
                            action = "Index",
                            id = UrlParameter.Optional
                        }),
                        DataTokens = defaultNamespace
                    });
