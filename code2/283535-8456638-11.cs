    protected void Page_Load()
    {
        if(IsPostBack) 
        {        
            if(CrossPagePostback)
            {
                // Cross page postback succeeded (JavaScript enabled)
                HttpContext.Items.Add("CrossPagePostBack", true);
            }
            string name = PreviousPage.NameTextBox.Text;
            // Do something with Page 1's form value(s)
        }
    }
