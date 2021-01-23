    public class TableRowAttributeFix : TableRow
    {
        private StringBuilder AttributesOutput = new StringBuilder();
    
    
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (String _attributeKey in Attributes.Keys)
            {
                var _attributeValue = Attributes[_attributeKey];
    
                if (_attributeValue.Contains("\""))
                {
                    AttributesOutput.Append(String.Format(" {0}='{1}' ", _attributeKey, _attributeValue));
                }
                else
                {
                    AttributesOutput.Append(String.Format(" {0}=\"{1}\" ", _attributeKey, _attributeValue));
                }
            }
    
    
            writer.Write("<tr id=\"" + ClientID + "\" " + AttributesOutput + " class=\"" + CssClass + "\" >");
    
            RenderContents(writer);
    
            writer.Write("</tr>");
        }
    }
