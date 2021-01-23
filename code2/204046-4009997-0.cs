        Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
            AddHandler context.EndRequest, AddressOf Context_EndRequest
        End Sub
        Private Sub Context_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
            If TypeOf sender Is HttpApplication Then
                Dim hApplication As HttpApplication = DirectCast(sender, HttpApplication)
                Dim hContext As HttpContext = hApplication.Context
                If (hContext.Response.StatusCode = &H191) Then
                    hContext.Response.Redirect(String.Format("{0}?ReturnUrl={1}&someparam2={2}", basepath, HttpUtility.UrlEncode(hContext.Request.RawUrl), someparam2))
                End If
            End If
        End Sub
