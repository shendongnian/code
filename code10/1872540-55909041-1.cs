    Private Sub SomePageName_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If User.Identity.IsAuthenticated Then
                Console.WriteLine(User.Identity.GetUserName())
            Else
                Session("PageRedirect") = Request.Url
                Response.Redirect("/")
            End If
        End If
    End Sub
