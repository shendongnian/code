    protected void Page_Load(object sender, EventArgs e)
    {
        ctl1.ControlButtonClicked += new WebUserControl.ControlButtonClickedHandler(ctl1_ControlButtonClicked);
    }
    void ctl1_ControlButtonClicked(object sender, EventArgs e)
    {
        Response.Redirect("http://google.com");
    }
