    private void DisplayHtml(string html)
    {
        webBrowser1.Navigate("about:blank");
        if (webBrowser1.Document != null)
        {
            webBrowser1.Document.Write(string.Empty);
        }
        webBrowser1.DocumentText = html;
    }
