        protected void Page_Load(object sender, EventArgs e)
        {
            proj_name = Request.QueryString["project"].ToString();
            proj_id = Request.QueryString["id"].ToString();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((string)Session["iteration"]))
            {
                iteration = "0";
            }
            else
            {
                iteration = (string)Session["iteration"];
            }
            BindTagCloud();
        }
