    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rptCategories.DataSource = Category.GetAll();
            rptCategories.DataBind();
        }
    }
    protected void rptCategories_ItemDatabound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item) {
            var repeater = (Repeater)e.Item.FindControl("rptLinks");
            var category = (Category)e.Item.DataItem;
            repeater.DataSource = category.Links;
            repeater.DataBind();
        }
    }
