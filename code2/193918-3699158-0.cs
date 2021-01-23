    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Sitecore.Data.Items.Item contextItem = Sitecore.Context.Item;
            // ... the rest of the code
        }
    }
