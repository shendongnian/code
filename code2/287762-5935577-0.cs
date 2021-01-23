      public void Page_Load(Object sender, EventArgs e)
      {
        // Define the name and type of the client script on the page.
        String csName = "ButtonClickScript";
        Type csType = this.GetType();
    
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;
    
        // Check to see if the client script is already registered.
        if (!cs.IsClientScriptBlockRegistered(csType, csName))
        {
          StringBuilder csText = new StringBuilder();
          csText.Append("<script type=\"text/javascript\"> function DoClick() {");
          csText.Append("Form1.Message.value='Text from client script.'} </");
          csText.Append("script>");
          cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
        }
      }
