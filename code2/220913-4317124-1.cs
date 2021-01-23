    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDdlAggerationUnitId();
        }
    }
    
    private void BindDdlAggerationUnitId()
    {
        ddlAggerationUnitId.DataSource = ExternalAccount.GetAggregationUnits();
        ddlAggerationUnitId.DataTextField = "Value";
        ddlAggerationUnitId.DataValueField = "Key";
        ddlAggerationUnitId.DataBind();
    }
    public long? Value
    {
        get { return Int64.Parse(ddlAggerationUnitId.SelectedItem.Value); }
        set
        {
            ListItem item = null;
            if (value.HasValue && ddlAggerationUnitId.Items.Count > 0 && ddlAggerationUnitId.SelectedIndex > 1)
                item = ddlAggerationUnitId.Items.FindByValue(value.ToString());
            if ( item != null)
            {
                ddlAggerationUnitId.SelectedValue = value.ToString();
            }
        }
    }
