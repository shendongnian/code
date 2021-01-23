    private COFFEESHOPEntities1 CoffeeContext = new COFFEESHOPEntities1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //getData();
            cbxCategory.DataSource = CoffeeContext.tblProductTypes.ToList();
            cbxCategory.DataTextField = "Description";
            cbxCategory.DataValueField = "ProductType";
            cbxCategory.DataBind();
        }
    }
