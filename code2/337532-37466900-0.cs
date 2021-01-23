    Public Module WebApiConfig
        Public Sub Register(ByVal config As HttpConfiguration)
            'Run this method on startup to cache the addresses
            Address.GetAll()
            config.Routes.MapHttpRoute(
                name:="DefaultApi",
                routeTemplate:="api/{controller}/{id}",
                defaults:=New With {.id = RouteParameter.Optional}
            )
        End Sub
    End Module
