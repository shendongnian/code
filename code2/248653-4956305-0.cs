    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           DropDownList4.Visible=false;
        }
    }
