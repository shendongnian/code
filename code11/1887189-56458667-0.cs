       Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Session.Item("IndexOfAll") = 0
            loadMoreAccResultsOnPanel()
        End If
        If (ScriptManager.GetCurrent(Page).IsInAsyncPostBack) Then
            Session.Item("IndexOfAll") += 1
        End If
    End Sub
