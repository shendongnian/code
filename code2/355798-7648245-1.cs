    protected override void RenderContents(HtmlTextWriter w)
    {
        writer.WriteBeginTag("div");
        writer.WriteAttribute("id", this.ClientID);
        writer.WriteAttribute("class", cssClass);
        writer.Write(HtmlTextWriter.TagRightChar);
        foreach (DataListItem li in this.Items)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("id", li.ClientID);
            writer.WriteAttribute("class", li.CssClass);
            writer.Write(HtmlTextWriter.TagRightChar);
            li.CssClass = null; // clear css not to added in span
            li.RenderControl(w);
            writer.WriteEndTag("div");
        }
        writer.WriteEndTag("div");
    }
