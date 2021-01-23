    protected void Page_Init(object sender, EventArgs e)
    {
         System.Web.UI.HtmlControls.HtmlLink jqueryUICSS;
         jqueryUICSS = new System.Web.UI.HtmlControls.HtmlLink();
         jqueryUICSS.Href = "styles/jquery-ui-1.8.13.custom.css");
         jqueryUICSS.Attributes.Add("rel", "stylesheet");
         jqueryUICSS.Attributes.Add("type", "text/css");
         Page.Header.Controls.Add(jqueryUICSS);
    }
