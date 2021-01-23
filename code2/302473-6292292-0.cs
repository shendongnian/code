    protected override void Render(System.Web.UI.HtmlTextWriter writer)
            {
                
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
    
                HtmlTextWriter writer = new HtmlTextWriter(sw);
                base.Render(writer);
                string markupText = sb.ToString();
                // markupText will contain the HTML of the Page
                writer.Write(markupText);
            }
