    private TextBox getUserNameTextBox(ControlCollection ctls)
        {
            foreach (Control c in ctls)
            {
                if (c is System.Web.UI.WebControls.TextBox)
                {
                    if (c.ID == "UserName")
                        return c;
                }
                if (c.HasControls())
                {
                    getAllCtl(c.Controls);
                   
    
                }
            }
            return null;
        }
    
    YourUserNameTextBox = getuserNameTextBox(Page.Controls);
