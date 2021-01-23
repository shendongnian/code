    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        
        ' Store a reference...only do this once etc etc
        If SessionHelper.TheSession Is Nothing Then
            SessionHelper.TheSession = HttpContext.Current.Session
        End If
        
    End Sub
