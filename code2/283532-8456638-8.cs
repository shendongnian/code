    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack && HttpContext.Items.Contains("CrossPagePostBack") == false)
        {
           // Cross page postback did not succeed (JavaScript disabled)
           string name = NameTextBox.Text;
           HttpContext.Items.Add("Name", name);
           HttpContext.Items.Add("Transfer", true);
           Server.Transfer("Page2.aspx");
        }
    }
