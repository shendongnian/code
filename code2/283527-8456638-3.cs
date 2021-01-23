    protected void Page_Load()
    {
        if(IsPostBack) 
        {
            // Either way we get here, prevent a loop from happing in Page 1
            HttpContext.Items.Add("transferred", true);
            string name = PreviousPage.NameTextBox.Text;
        
            if(CrossPagePostback == false)
            {
                // Cross page postback did not succeed, so we got transferred
                
            }
            else
            {
                // Cross page postback succeeded (JavaScript enabled)
                
            }
        }
    }
