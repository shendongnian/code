    HtmlElement content = this.wb.Document.GetElementById("content");
    HtmlElement username = content.Document.All["username"];
    username.SetAttribute("value", "Username");
    HtmlElement pass = content.Document.All["password"];
    pass.SetAttribute("value", "Password");  
        
    HtmlElementCollection htmlCol = webBrowser.Document.GetElementsByTagName("input");
    foreach (HtmlElement el in htmlCol)
    {
        if ((el.Name == "submit") && (el.GetAttribute("value") == "Value of submit button"))
        {
           el.InvokeMember("click");
           break;
        }
    }
