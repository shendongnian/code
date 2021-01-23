    protected void Page_Load(object sender, EventArgs e)
    {
        WebUserControl.PreRender += new EventHandler(WebUserControl_PreRender);
    }
    void WebUserControl_PreRender(object sender, EventArgs e)
    {
        string str = WebUserControl.MyTitle;
        this.Header.Title = str;
    }
