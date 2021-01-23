    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack() && Request.QueryString["ind"] != null)
        {
            SetIndustry(Request.QueryString["ind"].ToString());
        }
    }
    protected void SetIndustry(String industry)
    {
        indLabel.Text = "Industry: " + industry;
        IndustryDropDownList.SelectedValue = industry;
    }
