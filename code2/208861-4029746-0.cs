    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string[] ds = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            DLID.DataSource = ds;
            DLID.DataBind();
        }
    }
    protected void Item_OnClick(object sender, EventArgs e)
    {
        //do stuff
    }
