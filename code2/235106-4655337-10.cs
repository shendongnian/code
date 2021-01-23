    Imports System.Web
    
    ' http://support.microsoft.com/kb/308000
    ' http://www.c-sharpcorner.com/UploadFile/hemantkathuria/ASPNetHttpModules11262005004251AM/ASPNetHttpModules.aspx
    ' http://www.15seconds.com/issue/020417.htm
    ' http://www.worldofasp.net/tut/prjaspxmod/ASPNET_HTTP_Modules_168.aspx
    ' http://dotnetslackers.com/articles/aspnet/ErrorLoggingModulesAndHandlers.aspx
    ' http://www.stardeveloper.com/articles/display.html?article=2009071801&page=1
    ' http://www.devx.com/dotnet/Article/6962/1954
    ' http://www.west-wind.com/weblog/posts/59731.aspx
    Public Class IPbanning
        Implements IHttpModule
        Private Shared m_scIPadresses As System.Collections.Specialized.StringCollection = FillBlockedIps()
        Public Sub Dispose() Implements System.Web.IHttpModule.Dispose
        End Sub
        Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
            AddHandler context.BeginRequest, New EventHandler(AddressOf context_BeginRequest)
            'AddHandler context.EndRequest, New EventHandler(AddressOf IHttpModule_Dispose)
        End Sub
        ''' <summary>
        ''' Checks the requesting IP address in the collection
        ''' and block the response if it's on the list.
        ''' </summary>
        Private Sub context_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
    
            Dim strIP As String = HttpContext.Current.Request.UserHostAddress
    
            If String.IsNullOrEmpty(strIP) Then
                HttpContext.Current.Response.Write("<h1>Server-Error: IP is NULL</h1>")
                HttpContext.Current.Response.End()
                Exit Sub
            End If
            If strIP = "127.0.0.2" Then
                HttpContext.Current.Response.Write("<h1 style=""color: blue;""><font color=""red"">YOU</font> (" + HttpContext.Current.Request.UserHostAddress.ToString() + ") are banned.</h1>")
                'HttpContext.Current.Response.StatusCode = 403
                HttpContext.Current.Response.End()
            End If
            If (m_scIPadresses.Contains(strIP)) Then
                HttpContext.Current.Response.StatusCode = 403
                HttpContext.Current.Response.End()
            End If
        End Sub
        ''' <summary>
        ''' Retrieves the IP addresses from the web.config
        ''' and adds them to a StringCollection.
        ''' </summary>
        ''' <returns>A StringCollection of IP addresses.</returns>
        Private Shared Function FillBlockedIps() As System.Collections.Specialized.StringCollection
    
            Dim scIPcollection As System.Collections.Specialized.StringCollection = New System.Collections.Specialized.StringCollection()
            'Dim strRaw As String = ConfigurationManager.AppSettings.Get("blockip")
            Dim strRaw As String = "44.0.234.122, 23.4.9.231"
            strRaw = strRaw.Replace(",", ";")
            strRaw = strRaw.Replace(" ", ";")
    
            For Each strIP As String In strRaw.Split(";")
                scIPcollection.Add(strIP.Trim())
            Next
    
            Return scIPcollection
        End Function
    End Class
