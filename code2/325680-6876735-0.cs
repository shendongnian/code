     protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.RenderContents(writer);
    writer.BeginRender();
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.Write("myJavaScriptVar = (\" + myC#Var + \")"); 
    writer.RenderEndTag();
