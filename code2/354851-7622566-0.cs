    protected void Page_Load(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(Request.QueryString["iframe"]))
        {
            if(Convert.ToBoolean(Request.QueryString["iframe"])
            {
                // this page is loaded in an iframe
            }
        }
    }
