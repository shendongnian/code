    Public Shared Sub RegisterRoutes(routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        Dim config = New HttpConfiguration() With { _
            .EnableTestClient = True _
        }
        routes.Add(New ServiceRoute("api/contacts", New HttpServiceHostFactory() With { _
            .Configuration = config _         <-----------Name of field or property being initialized in an object initializer must start with '.'. 
        }, GetType(ContactsApi)))
        ' Route name
        ' URL with parameters
        ' Parameter defaults
        routes.MapRoute("Default", "{controller}/{action}/{id}", New With { _
         Key .controller = "Home", _
         Key .action = "Index", _
         Key .id = UrlParameter.[Optional] _
        })
    End Sub     
