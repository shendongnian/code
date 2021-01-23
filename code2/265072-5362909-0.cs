    HtmlGenericControl style = new HtmlGenericControl();
    style.TagName = "style";
    style.Attributes.Add("type", "text/css");
    style.InnerHtml = "body{background-color:#000000;}";
    Page.Header.Controls.Add(style); 
