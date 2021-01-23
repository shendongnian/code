    webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
    void webBrowser1_DocumentCompleted (object sender, EventArgs e)
    {
        IEnumerable<HtmlElement> inputs = webBrowser1.Document.All
            .OfType<HtmlElement>()
            .Where(el => String.Equals(el.TagName, "input", StringComparison.OrdinalIgnoreCase));
    }
