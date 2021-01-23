    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // bind / load lists and controls here
        }
        else
        {
           //this is a post back, don't reload everything
        }
    }
