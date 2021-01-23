    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList ProfilesView;
            PycDBDataContext db = new PycDBDataContext();
            IEnumerable<seller_profile> profs = from rows in db.seller_profiles select rows;
            ProfilesView.DataSource = profs;
            ProfilesView.ItemDataBound += new DataListItemEventHandler(ProfilesView_ItemDataBound);
            ProfilesView.DataBind();
        }
    }
    private void ProfilesView_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor = 'lightblue';");
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor = 'white';");
        }
    }
