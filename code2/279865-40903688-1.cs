    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace NAMESPACE_Web
    {
        public partial class History1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "helloFromCodeBehind()", true);
            }
    
        }
    }
