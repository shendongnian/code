	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			BindDdlAggerationUnitId();
		}
	}
	private void BindDdlAggerationUnitId()
	{
		ddlAggerationUnitId.DataSource = SIGOpsGUI.App_Code.Business.ExternalAccount.GetAggregationUnits();
		ddlAggerationUnitId.DataTextField = "Value";
		ddlAggerationUnitId.DataValueField = "Key";
		ddlAggerationUnitId.DataBind();
	}
	public long? Value
	{
		get { return Int64.Parse(ddlAggerationUnitId.SelectedItem.Value); }
		set
		{
			BindDdlAggerationUnitId();
			ddlAggerationUnitId.SelectedIndex = -1;
			ListItem item = ddlAggerationUnitId.Items.FindByValue(value.ToString());
			if (item != null)
			{
				ddlAggerationUnitId.SelectedValue = value.ToString();
			}
		}
	}
