    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["yesID"] = 0;
            Session["noId"] = 0;
        }
        //else
        //{
            //Send Session Variables to Database for Storage.
        //}
    }
    protected void FirstPicLink_Click(object sender, ImageClickEventArgs e)
    {
        Session["yesID"] = 1;
        Session["noId"] = 2;
        SendSessionVariables(Session["yesID"], Session["noId"]);
    }
    private void SendSessionVariables(object p, object p_2)
    {
        // Your database code here
    }
    protected void SecondPicLink_Click(object sender, ImageClickEventArgs e)
    {
        Session["yesID"] = 2;
        Session["noId"] = 1;
        SendSessionVariables(Session["yesID"], Session["noId"]);
    }
