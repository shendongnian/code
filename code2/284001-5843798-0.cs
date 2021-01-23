    Public Overrides Sub RegisterArea(ByVal context As System.Web.Mvc.AreaRegistrationContext)
            context.MapRoute( _
                "Test_default", _
               "Test/{controller}/{action}/{id}", _
                New With {.action = "Index", .id = UrlParameter.Optional}, _
                New With {"MyDefaultNamespace/Areas/Test/Controllers"} _
            )
    End Sub
