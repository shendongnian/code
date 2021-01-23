    protected void Page_Load()
    {
        if(IsPostBack)
        {
            string name;
            if(CrossPagePostBack)
            {
                // Cross page postback succeeded (JavaScript was enabled)
                HttpContext.Items.Add("CrossPagePostBack", true);
                name = PreviousPage.NameTextBox.Text;
            }
            else if (HttpContext.Items.Contains("Transferred"))
            {
                // We got transferred to from Page1.aspx
                name = (string)HttpContext.Items["Name"];
            }
        }
    }
