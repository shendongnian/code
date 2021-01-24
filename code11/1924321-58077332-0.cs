    private void geckoWebBrowser1_DocumentCompleted(object sender, EventArgs e)
    {
        var elements = geckoWebBrowser1.Document.GetElementsByTagName("a");
        foreach (GeckoHtmlElement element in elements)
        {
            if (element.ClassName == "violet")
            {
                element.ScrollIntoView(false);
                element.Click();
            }
         }
    }
