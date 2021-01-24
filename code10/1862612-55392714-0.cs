    private void webbrowser1_DocumentCompleted(object sender, DocumentCompletedEventArgs e)
    {
         if(webbrowser1.Url.EndsWith("login.aspx")  //check if it is the login url
         {
              var doc = webbrowser1.Document;
              doc.GetElementById("email").SetAttribute("value", email);
              doc.GetElementById("password").SetAttribute("value", password);
              doc.GetElementsByTagName("input").OfType<HtmlElement>()
                   .FirstOrDefault(x => x.GetAttribute("type") == "submit"))
                   .InvokeMember("click");
         }
         else
         {
               webbrowser1.Navigate(repUrl);
         }
    
    
    }
