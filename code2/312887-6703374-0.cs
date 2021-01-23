    public string ReplaceTextBoxByLabel(string htmlContent) 
    {
      HtmlDocument doc = new HtmlDocument();
      doc.LoadHtml(htmlContent);
    
      foreach(HtmlNode tb in doc.DocumentNode.SelectNodes("//input[@type='text']"))
      {
        string value = tb.Attributes.Contains("value") ? tb.Attributes["value"].Value : "&nbsp;";
        HtmlNode lbl = doc.CreateElement("span");
        lbl.InnerHtml = value;
    
        tb.ParentNode.ReplaceChild(lbl, tb);
      }
    
      return doc.DocumentNode.OuterHtml;
    }
