    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ViewState["List1_Value"] != null)
            {
                DropDownList1.SelectedValue = ViewState["List1_Value"].ToString();
            }
            else
            {
                DropDownList1.SelectedValue = "R";
            }
        }
    }
