    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            _renderDynamic(); // this method will be called if there is an postback event to re-render the dynamic controls
        }
    }
