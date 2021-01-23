    HtmlGenericControl dynDiv = new HtmlGenericControl("div");
    dynDiv = Replace(dynDiv, "&#39;", "'");
    public HtmlGenericControl Replace(HtmlGenericControl htmlGenericControl, string    
    source, string target)
    {
         StringWriter sw = new StringWriter();
         HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);
         htmlGenericControl.RenderControl(htmlTextWriter);
         string str = sw.GetStringBuilder().ToString();
         str = str.Replace(source, target);
         htmlGenericControl.InnerHtml = str;
         return htmlGenericControl;
    }
