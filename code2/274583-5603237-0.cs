    var elements = m_Browser.Document.GetElementsByTagName("button");
    foreach (HtmlElement element in elements)
    {
         // If there's more than one button, you can check the
         //element.InnerHTML to see if it's the one you want
         if (element.InnerHTML.Contains("Send Invitations"))
         {
              element.InvokeMember("click");
         }
    }
