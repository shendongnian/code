     Dim allelements As HtmlElementCollection = WebBrowser1.Document.All
        For Each webpageelement As HtmlElement In allelements
            If webpageelement.GetAttribute("value") = "Like" Then
                webpageelement.InvokeMember("click")                
            End If
        Next
