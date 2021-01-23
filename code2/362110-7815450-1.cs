    protected void Page_Load(object sender, EventArgs e)
    {
        // Define the name and type of the client scripts on the page.
        String csname1 = "PageStartUpScript";
        Type cstype = this.GetType();
    
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;
    
        // Check to see if the startup script is already registered.
        if (!cs.IsStartupScriptRegistered(cstype, csname1))
        {
            StringBuilder cstext1 = new StringBuilder();
            cstext1.Append(@"$(document).ready(function() {
                                    // add your startup.init functions here
                                  });");
    
            cs.RegisterStartupScript(cstype, csname1, cstext1.ToString(), true);
        }
    }
