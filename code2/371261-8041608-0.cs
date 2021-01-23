    protected void Page_Load(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["IsReviewServer"] == "Yes") 
        { 
            if (!Request.IsSecureConnection) 
            { 
                string path = string.Format("https{0}", Request.Url.AbsoluteUri.Substring(4)); 
     
                Response.Redirect(path); 
            } 
        } 
    }
