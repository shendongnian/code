    if (!IsPostBack)
    {
        if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["folder"].ToString())))
        {
            strheadlinesid1 = Request.QueryString["folder"].ToString();
    
        }
    }
