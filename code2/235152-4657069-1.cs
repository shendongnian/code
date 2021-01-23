        protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
        String[] d1 = { "1", "2", "3" };
        String[] d2 = { "4", "5", "6", "7" };
        ListView1.DataSource = d1;
        ListView1.DataBind();
        ListView2.DataSource = d2;
        ListView2.DataBind();
       }
    }
