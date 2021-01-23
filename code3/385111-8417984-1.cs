    StringBuilder sb = new StringBuilder();
    using (StringWriter sw = new StringWriter(sb))
    {
        using (HtmlTextWriter textWriter = new HtmlTextWriter(sw))
        {
            textBox.RenderControl(textWriter);
        }
    }
