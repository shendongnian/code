    protected void Page_Load()
    {
        if(IsPostBack) 
        {
            // Either way we get here, prevent a loop from happing in Page 1
            HttpContext.Items.Add("Transferred", true);
            string name = PreviousPage.NameTextBox.Text;
        
            if(CrossPagePostback)
            {
                // Cross page postback succeeded (JavaScript enabled)
                HttpContext.Items.Add("CrossPagePostBack", true);
            }
        }
    }
