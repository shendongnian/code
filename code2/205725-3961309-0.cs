      htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.Ul);
      htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.Li);
      htmlTextWriter.AddAttribute(HtmlTextWriterAttribute.Href, "http://www.google.de");
      htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.A);
      htmlTextWriter.Write("Google");
      htmlTextWriter.RenderEndTag(); //A
      htmlTextWriter.RenderEndTag(); //LI
      htmlTextWriter.RenderEndTag(); //UL
