    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
           // Cross page postback did not succeed (JavaScript disabled)
           string name = NameTextBox.Text;
           HttpContext.Items.Add("name", name);
           Server.Transfer("Page2.aspx");
        }
    }
