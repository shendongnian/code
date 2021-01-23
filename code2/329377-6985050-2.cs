        protected void Page_Init(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl mystyles;
            mystyles = new System.Web.UI.HtmlControls.HtmlGenericControl();
            mystyles.TagName = "style";
            string sampleCSS = "body { color: Black; } h1 {font-weight: bold;}";
            mystyles.InnerText = sampleCSS;
            Page.Header.Controls.Add(mystyles);
        }
