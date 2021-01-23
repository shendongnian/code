    private void Page_Load(...)
    {
        if(!Page.IsPostBack)
        {
            InitData();
        }
    }
    
    private void InitData()
    {
        //Do init data control in your page
        // For exp: binding the grid, combo box....
    }
    
    protected void btn_Update_Clicked(...)
    {
        //1. Update database
        //2. Call InitData() function to reload data from database
    }
