    public void Submit1_Click(Object sender, EventArgs E)
    {
        string strheadlinesid1 = string.Empty;
    
        if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["folder"].ToString())))
        {
            strheadlinesid1 = Request.QueryString["folder"].ToString();
        }
    
        string URL = "view4.aspx?value="+strheadlinesid1;
    
        Response.Redirect(URL);
    }
