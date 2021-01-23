          protected void Page_Load(object sender, System.EventArgs e)
          {                
              ScriptManager.RegisterStartupScript(this.Page, 
                  this.Page.GetType(), mce.ClientID, "callInt" + mce.ClientID + "();",  true);
           }
