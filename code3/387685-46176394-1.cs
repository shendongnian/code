    Private Sub Web_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Web.DocumentCompleted
        If Me.Visible = False Then
            For Each f As Form In My.Application.OpenForms
                If TypeOf f Is frmLogin Then
                    Dim fl As frmLogin = DirectCast(f, frmLogin)
                    If fl.Visible = True Then
                        fl.Focus()
                        Exit For
                    End If
                End If
            Next
        End If
    end sub
