    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "DoStuff" Then
            'Do something with e.CommandArgument'
        End If
    End Sub
