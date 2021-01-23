    Dim http = Web.HttpContext.Current
    If Not http Is Nothing Then
        Dim page = TryCast(http.CurrentHandler, Web.UI.Page)
        If Not page Is Nothing Then
             Dim scriptManager = System.Web.UI.ScriptManager.GetCurrent(page)
        End If
    End If
