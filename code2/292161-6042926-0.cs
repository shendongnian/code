        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Sitecore.Context.PageMode.IsPreview)
            {
                // Not in preview mode
                Response.Redirect("redirectionurl.aspx");
            }
        }
