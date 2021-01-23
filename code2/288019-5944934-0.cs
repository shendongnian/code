    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Error += new EventHandler(Page_Error);
    }
    
    void Page_Error(object sender, EventArgs e)
    {
        Exception exception = Server.GetLastError();
            
        Response.Write(exception.ToString());
            
        HttpContext.Current.ClearError();
    }
