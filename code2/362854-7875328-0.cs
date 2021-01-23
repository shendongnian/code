    protected override void RenderFieldForDisplay(HtmlTextWriter output)
    {
      TextWriter tempWriter = new StringWriter();
      base.RenderFieldForDisplay(new HtmlTextWriter(tempWriter));
      string html =  tempWriter.ToString();
      string nbsp = "&#160;";
      string brTag = "<br/>";
      html = html.Equals(nbsp) ? html.Replace(nbsp, string.Empty) : html.Replace(" ", nbsp).Replace("\r\n", brTag).Replace("\n", brTag).Replace("\r", brTag);
      output.Write(html);
    }
  
