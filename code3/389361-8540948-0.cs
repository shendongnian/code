    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && string.IsNullOrEmpty(Request.QueryString["forceLogout"]))
        {
            // log the user out 
        }
        else
        {
            // Your original logic
        }
    }
