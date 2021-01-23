        private void BeginOperation()
        {
            webBrowser1.Navigate("somewebpage", false);
            Task = 0;
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement elem;
            switch (Task)
            {
                case 0:
                    //HtmlDocument mydoc = webBrowser1.Document;
                     elem = webBrowser1.Document.GetElementById("ddlCity");
                    MessageBox.Show(elem.All.Count.ToString());
                    elem.SetAttribute("selectedIndex", "1");
                    //elem.RaiseEvent("onChange");
                    object[] args = {"someparameters"};
                    webBrowser1.Document.InvokeScript("__doPostBack",args);
                    Task++;
                break;
                case 1:
                    elem = webBrowser1.Document.GetElementById("ddlDistrict");
                    elem.SetAttribute("selectedIndex", "2");
                    elem.RaiseEvent("onChange");
                    object[] args2 = {"someparameters"};
                    webBrowser1.Document.InvokeScript("__doPostBack",args2);
                    Task++;
                break;
            }
         }
