     protected void Page_Load(object sender, EventArgs e)
     {
     //This method return a dictionary with a URL, and a name
        if (!Page.IsPostBack)
            this.BindDate((Dictionary<string, string>)MyLibrary.Data.DataHelper.GetMytList());
     }
     private void BindDate(Dictionary<string, string> dict)
     {
        this.RestList.ItemDataBound += new RepeaterItemEventHandler(e_ItemDataBound);
        this.RestList.DataSource = dict;
        this.RestList.DataBind();
     }
     void e_ItemDataBound(object sender, RepeaterItemEventArgs e)
     {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            KeyValuePair<string, string> mydict = (KeyValuePair<string, string>)e.Item.DataItem;
            HyperLink Link = (HyperLink)e.Item.FindControl("MyLink");
            Link.NavigateUrl = mydict.Value.ToString();
            Link.Text = mydict.Key.ToString();
        }
     }
