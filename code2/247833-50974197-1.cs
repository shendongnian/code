    public System.Windows.Forms.HtmlDocument GetHtmlDocument(string html)
    {
        WebBrowser browser = new WebBrowser();
        browser.DocumentText = html;
        browser.Document.Write(html);
        return browser.Document;
    }
