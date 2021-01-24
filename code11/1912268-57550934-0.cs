    Dim loginAddresses As New Dictionary(Of Uri, String)() From {
        {New Uri("https://kite.zerodha.com"), "testId|TestPassword1"},
        {New Uri("https://www.someothersite.com/login") "user@domain.com|ThePassword1"}
    }
    Private Async Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim wb As WebBrowser = DirectCast(sender, WebBrowser)
        If wb.ReadyState <> WebBrowserReadyState.Complete OrElse wb.Document.Forms.Count = 0 Then Return
        Dim values As String = String.Empty
        If loginAddresses.TryGetValue(wb.Url, values) Then
            Dim usrPwd = values.Split("|"c)
            Await DoWebFormLogin(wb, usrPwd(0), usrPwd(1))
        End If
    End Sub
    Private Async Function DoWebFormLogin(wb As WebBrowser, usrId As String, pwd As String) As Task
        Dim userIDSet As Boolean = False
        Dim passwordSet As Boolean = False
        Dim inputElms = wb.Document.GetElementsByTagName("INPUT").OfType(Of HtmlElement)().ToList()
        If inputElms.Count < 2 Then
            Return
        End If
        For Each elm As HtmlElement In inputElms
            If elm.GetAttribute("type").Equals("text") Then
                elm.Focus()
                Await Task.Delay(50)
                elm.InnerText = usrId
                elm.SetAttribute("value", usrId)
                userIDSet = True
            End If
            If elm.GetAttribute("type").Equals("password") Then
                elm.Focus()
                Await Task.Delay(50)
                elm.InnerText = pwd
                elm.SetAttribute("value", pwd)
                passwordSet = True
            End If
            If userIDSet AndAlso passwordSet Then
                Dim buttonElms = wb.Document.GetElementsByTagName("BUTTON").OfType(Of HtmlElement)().ToList()
                For Each button As HtmlElement In buttonElms
                    If button.GetAttribute("type").Equals("submit") Then
                        button.Focus()
                        Await Task.Delay(50)
                        button.InvokeMember("click")
                        Exit For
                    End If
                Next
            End If
        Next
    End Function
