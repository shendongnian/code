    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace YourNameSpace
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // Define the name and type of the client scripts on the page.
  		// Define the name and type of the client scripts on the page.
		String csname1 = "PopupScript";
		Type cstype = this.GetType();
		// Get a ClientScriptManager reference from the Page class.
		ClientScriptManager cs = Page.ClientScript;
		// Check to see if the startup script is already registered.
		if (!cs.IsStartupScriptRegistered(cstype, csname1))
		{
		    StringBuilder cstext1 = new StringBuilder();
		    cstext1.Append("<script type=text/javascript> alert('Hello World!') </");
		    cstext1.Append("script>");
		    cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
		}
            }
        }
    }
