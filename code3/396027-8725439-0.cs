      protected override void RenderContents(HtmlTextWriter output)
      {
            output.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            output.AddAttribute(HtmlTextWriterAttribute.Type, Text);
            output.AddAttribute(HtmlTextWriterAttribute.Value, Value);
            output.RenderBeginTag(HtmlTextWriterTag.Input);
            output.RenderEndTag();
      }
