    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {            
            if (!String.IsNullOrEmpty(Portal.Common.Objects.CommonSessionHelper.Instance.IframeUrl))
            {
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.WriteFile(Portal.Common.Objects.CommonSessionHelper.Instance.IframeUrl);            
                Response.Flush();
                Response.Close();
                Portal.Common.Objects.CommonSessionHelper.Instance.IframeUrl = null;
            }
        }
        catch (Exception error)        
        {
            Response.Write(error.Message);
        }
    }
