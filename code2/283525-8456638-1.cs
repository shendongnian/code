    protected void Page_Load()
    {
        if(IsPostBack)
        {
            string name;
            if(HttpContext.Items["name"] != null)
            {
                // We got transferred to from Page1.aspx
                name = (string)HttpContext.Items["name"];
            }
            else
            {
                // Cross page postback succeeded (JavaScript was enabled)
                name = PreviousPage.NameTextBox.Text;
            }
        }
    }
