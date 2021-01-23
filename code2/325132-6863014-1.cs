    <%@ Import Namespace="System.Configuration.ConfigurationManager" %>
    ...
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
      Application("cn") = ConnectionStrings(System.Web.HttpContext.Current.Request.ServerVariables("HTTP_HOST"))
    End Sub
