    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var qurey = GetNationality();
            var national = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Nationality");
            national.DataSource = qurey;
            national.DataTextField = "CountryName";
            national.DataValueField = "Id";
            national.DataBind();
            var item = new ListItem("Select Country", "");
            national.Items.Insert(0, item);
    
        }
    
    }
