    Public Sub Show(message As String)
        Dim cleanMessage As String = message.Replace("'", "\'")
        Dim page As Page = HttpContext.Current.CurrentHandler
        Dim script As String = String.Format("alert('{0}');", cleanMessage)
        If (page IsNot Nothing And Not page.ClientScript.IsClientScriptBlockRegistered("alert")) Then
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, True) ' /* addScriptTags */
        End If
    End Sub
