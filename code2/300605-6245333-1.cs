     private void webBrowser1_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
            {
      System.Windows.Forms.HtmlElementCollection elementsforViewPost =
                                    webBrowser1.Document.GetElementsByTagName("font");
      foreach (System.Windows.Forms.HtmlElement current2 in elementsforViewPost)
      {
      if (current2.InnerText != null && CheckForValidProxyAddress(current2.InnerText) &&
                        ObtainedProxies.Where(index=>index.ProxyAddress == current2.InnerText.Trim()).ToList().Count == 0)
     {
       Proxy data = new Proxy();
       data.IsRetired = false;
       data.IsActive = true;
       int result = 1;                   
    
       data.DomainsVisited = 0;
       data.ProxyAddress = current2.InnerText.Trim();
    
       ObtainedProxies.Add(data);
    }
