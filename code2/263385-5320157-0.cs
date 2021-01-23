    protected override void Render(HtmlTextWriter writer)
    {
        string pageSource;
        // setup a TextWriter to capture the markup
        using (var sw = new StringWriter())
        using (var htw = new HtmlTextWriter(sw))
        {
            // render the markup into our surrogate TextWriter
            base.Render(htw);
            // get the captured markup
            pageSource = sw.ToString();
        }
        // render the markup into the output stream
        writer.Write(pageSource);
        // now you can do what you like with the captured markup in pageSource
    }
