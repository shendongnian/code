	protected override void OnInit(EventArgs e)
	{
		this.rptHtmlTag.ItemDataBound += new RepeaterItemEventHandler(rptHtmlTag_ItemDataBound);
		this.btnSubmit.Click += new EventHandler(btnSubmit_Click);
		base.OnInit(e);
	}
	void btnSubmit_Click(object sender, EventArgs e)
	{
		foreach (RepeaterItem item in this.rptHtmlTag.Items)
		{
			HtmlInputText htmlTextBox = (HtmlInputText)item.FindControl("htmlTextBox");
			string THIS_IS_YOUR_VALUE = htmlTextBox.Value;
		}
	}
	void rptHtmlTag_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			HtmlInputText htmlTextBox = (HtmlInputText )e.Item.FindControl("htmlTextBox");
			htmlTextBox.Value = String.Concat("Some Value - Index", e.Item.ItemIndex);
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			List<int> repeaterPopulator = new List<int> { 1, 2, 3 };
			this.rptHtmlTag.DataSource = repeaterPopulator;
			this.rptHtmlTag.DataBind();
		}
	}
