    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            txt_to.Focus()
        End If
        txt_to.Attributes.Add("OnKeyPress", "GetKeyPress()")
    End Sub
