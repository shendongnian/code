    Public Shared Sub redirectIfNotServer(ByVal redirectUrl As String)
        ' Look for a proxy address first
        Dim IP = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        'Trim and lowercase IP if not null
        If Not IP Is Nothing Then
            IP = IP.ToLower().Trim
        End If
        If IP Is Nothing OrElse (IP.Equals("unknown")) Then
            'If IP is null use different detection method, else pull the correct IP from list.
            IP = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToLower().Trim
        End If
    
        Dim IPs As List(Of String)
        If IP.IndexOf(",") > -1 Then
            IPs = IP.Split(","c).ToList
        Else
            IPs = New String() {IP}.ToList
        End If
    
        Dim serverIP = HttpContext.Current.Request.ServerVariables("LOCAL_ADDR")
        Dim ipIsServerIp = (From ipAddress In IPs Where ipAddress = serverIP).Any
        If Not ipIsServerIp Then
            HttpContext.Current.Response.Redirect(redirectUrl)
        End If
    End Sub
