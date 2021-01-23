    private void DisplayHtml(string html)
    {
        webBrowser1.Navigate("about:blank");
        try
        {
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
        }
        catch (CastException e)
        { } // do nothing with this
        webBrowser1.DocumentText = html;
    }
