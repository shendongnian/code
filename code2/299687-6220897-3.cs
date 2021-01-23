    private bool m_bIsTerminating = false;
>    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WeNeedToRedirect == true)
        {
            Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            m_bIsTerminating = true;
