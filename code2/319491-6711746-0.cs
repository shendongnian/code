    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Name"] != null)
                    txtName.Text = Session["Name"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Name"] = txtName.Text;
            Response.Redirect("Page2.aspx");
        }
