I use this technique in my application.  I host a WebBrowser, and I populated it as follows:
    public void DisplayHtml(HtmlGenerator gen)
    {
            webBrowser.DocumentText = gen.GenerateHtmlString());
    }
