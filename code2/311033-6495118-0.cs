    protected void Page_Load(object sender, EventArgs e) { 
    if(!IsPostBack)
    {
       BLgetMasterData obj = new BLgetMasterData();
       var cusineList = obj.getCuisines();
       CuisineList.DataSource = cusineList;
       CuisineList.DataBind();
       CuisineList.Items.Insert(0, "Any");
    }
    }
