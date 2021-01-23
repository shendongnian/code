    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            base.BasePageInitialized += new EventHandler(Base_Initialized);
    }
    protected void Base_Initialized(object sender, EventArgs e)
    {
        base.SetLiteral(value)
    }
 
