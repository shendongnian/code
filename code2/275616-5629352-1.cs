    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MyRepeater.DataSource = GetDataSource();
            MyRepeater.DataBind(); 
        }
    }
    protected void MyRepeater_OnItemDataBound(object sender, RepeaterEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
       {
            // This will be your data object
            MyEntity o = (MyEntity) e.Item.DataItem;
            // Get the labels
            Label RegularPriceLabel = (Label) e.Item.FindControl("RegularPriceLabel");
            Label BuyNowPriceLabel = (Label) e.Item.FindControl("BuyNowPriceLabel");
            // Only show regular price if it is set
            RegularPriceLabel.Visible = (o.RegularPrice > 0);
            // Populate labels
            RegularPriceLabel.Text = o.RegularPrice.ToString();
            BuyNowPriceLabel.Text = o.BuyNowPrice.ToString();
            
       }
    }
