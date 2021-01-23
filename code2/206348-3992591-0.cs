    Imports System.Web
    Imports System.Web.Services.Protocols
    
    
    ' http://msdn.microsoft.com/en-us/library/9z52by6a.aspx
    ' http://msdn.microsoft.com/en-us/library/9z52by6a(VS.80).aspx
    
    
    
    
    ' http://www.codeproject.com/KB/cpp/authforwebservices.aspx
    
    
    ' http://aleemkhan.wordpress.com/2007/09/18/using-wse-30-for-web-service-authentication/
    ' http://www.codeproject.com/KB/WCF/CustomUserNamePassAuth2.aspx
    ' http://www.codeproject.com/KB/WCF/CustomUserNamePassAuth2.aspx
    ' http://www.codeproject.com/KB/webservices/WS-Security.aspx
    
    
    
    
    'Public NotInheritable Class WebServiceAuthenticationModule
    Public Class WebServiceAuthenticationModule
        Implements System.Web.IHttpModule
    
        Protected Delegate Sub WebServiceAuthenticationEventHandler(ByVal sender As [Object], ByVal e As WebServiceAuthenticationEvent)
        Protected _eventHandler As WebServiceAuthenticationEventHandler = Nothing
    
    
    
        Protected Custom Event Authenticate As WebServiceAuthenticationEventHandler
            AddHandler(ByVal value As WebServiceAuthenticationEventHandler)
                _eventHandler = value
            End AddHandler
            RemoveHandler(ByVal value As WebServiceAuthenticationEventHandler)
                _eventHandler = value
            End RemoveHandler
            RaiseEvent(ByVal sender As Object,
                    ByVal e As WebServiceAuthenticationEvent)
            End RaiseEvent
        End Event
    
    
        Protected app As HttpApplication
    
    
        Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
            app = context
    
            context.Context.Response.Write("<h1>Test</h1>")
    
            AddHandler app.AuthenticateRequest, AddressOf Me.OnEnter
        End Sub
    
    
        Public Sub Dispose() Implements System.Web.IHttpModule.Dispose
            ' add clean-up code here if required
        End Sub
    
    
        Protected Sub OnAuthenticate(ByVal e As WebServiceAuthenticationEvent)
            If _eventHandler Is Nothing Then
                Return
            End If
            _eventHandler(Me, e)
            If Not (e.User Is Nothing) Then
                e.Context.User = e.Principal
            End If
    
        End Sub 'OnAuthenticate 
    
    
        Public ReadOnly Property ModuleName() As String
            Get
                Return "WebServiceAuthentication"
            End Get
        End Property
    
    
        Sub OnEnter(ByVal [source] As [Object], ByVal eventArgs As EventArgs)
            'Dim app As HttpApplication = CType([source], HttpApplication)
            'app = CType([source], HttpApplication)
            Dim context As HttpContext = app.Context
            Dim HttpStream As System.IO.Stream = context.Request.InputStream
    
            ' Save the current position of stream.
            Dim posStream As Long = HttpStream.Position
    
            ' If the request contains an HTTP_SOAPACTION 
            ' header, look at this message.
    
            'For Each str As String In context.Request.ServerVariables.AllKeys
    
            'If context.Request.ServerVariables(Str) IsNot Nothing Then
            'context.Response.Write("<h1>" + Str() + "= " + context.Request.ServerVariables(Str) + "</h1>")
            'End If
            'Next
            If context.Request.ServerVariables("HTTP_SOAPACTION") Is Nothing Then
                'context.Response.End()
                Return
                'Else
                'MsgBox(New System.IO.StreamReader(context.Request.InputStream).ReadToEnd())
            End If
    
    
            ' Load the body of the HTTP message
            ' into an XML document.
            Dim dom As New System.Xml.XmlDocument()
            Dim soapUser As String
            Dim soapPassword As String
    
            Try
                dom.Load(HttpStream)
    
                'dom.Save("C:\Users\Administrator\Desktop\SoapRequest.xml")
                ' Reset the stream position.
                HttpStream.Position = posStream
    
                ' Bind to the Authentication header.
                soapUser = dom.GetElementsByTagName("Username").Item(0).InnerText
                soapPassword = dom.GetElementsByTagName("Password").Item(0).InnerText
            Catch e As Exception
                ' Reset the position of stream.
                HttpStream.Position = posStream
    
                ' Throw a SOAP exception.
                Dim name As New System.Xml.XmlQualifiedName("Load")
                Dim ssoapException As New SoapException("Unable to read SOAP request", name, e)
                context.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized
                context.Response.StatusDescription = "Access denied."
    
                ' context.Response.Write(ssoapException.ToString())
                'Dim x As New System.Xml.Serialization.XmlSerializer(GetType(SoapException))
                'context.Response.ContentType = "text/xml"
                'x.Serialize(context.Response.OutputStream, ssoapException)
    
    
                'Throw ssoapException
    
                context.Response.End()
            End Try
    
            ' Raise the custom global.asax event.
            OnAuthenticate(New WebServiceAuthenticationEvent(context, soapUser, soapPassword))
            Return
        End Sub 'OnEnter
    
    
    End Class ' WebServiceAuthenticationModule
