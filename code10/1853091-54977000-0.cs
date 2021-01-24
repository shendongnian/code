    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            int UserID = 0;
            if(Session["UserName"] != null) int.TryParse(Session["UserName"].ToString(), out UserID);                                             
            DataTable dt = this.GetData(UserID);
            PopulateMenu(dt, UserID, null);
        }
    }
