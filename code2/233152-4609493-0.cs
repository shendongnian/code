    public void writeDivWithStyle(HtmlTextWriter writer, string style)
    {
        writer.AddAttribute(HtmlTextWriterAttribute.Style, style);
        writer.RenderBeginTag(HtmlTextWriterTag.Div);
        // more code here
        writer.RenderEndTag(); // close the DIV
    }
