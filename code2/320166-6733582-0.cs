    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] list = Directory.GetFiles(Server.MapPath("sony"));
            var aList = from fileName in Directory.GetFiles(Server.MapPath("sony"))
                        select string.Format("/sony/{0}", Path.GetFileName(fileName));
                
            DataList1.DataSource = aList;
            DataList1.DataBind();
        }
    }
