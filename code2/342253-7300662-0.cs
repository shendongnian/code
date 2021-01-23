    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string kitty = Convert.ToString(Session["ping"]);
            Label1.Text = kitty;
        }
    }
