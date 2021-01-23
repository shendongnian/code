        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gdvxUsers.DataSource = GetAllUserAndRole();
                gdvxUsers.DataBind();
            }
        }
