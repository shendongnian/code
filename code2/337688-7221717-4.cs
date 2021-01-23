    public ICommand LoadCompleted
    {
        get
        {
            return new EventToCommandWithSender<NavigationEventArgs>(
                (s,e) => { 
                   WebBrowser browser = (WebBrowser) sender;
                   // false if nested frame
                   if (e.IsNavigationInitiator)
                   {
                       mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)browser.Document;
                       // always completed
                       var readyState = doc.readyState;
                       // populate form
                       var name = doc.body.document.getElementById("username");
                       name.value = "@TheCodeKing";
                       // submit form
                       var submit = doc.body.document.getElementById("submit");
                       submit.Click();
                    }
            });
        }
    }
