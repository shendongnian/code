       protected void Page_Load(object sender, EventArgs e)
    {
        //code        
        if (!m_mainController.m_IsAutorized)
        btnEditProfile.Enabled = false;
        Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
       //more code
    }
