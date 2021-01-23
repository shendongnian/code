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
            else if (HttpContext.Items.Contains("Transfer"))
            {
                // We got transferred to from Page1.aspx
                name = (string)HttpContext.Items["Name"];
            }
            // Do something with Page 1's form value(s)
        }
    }
