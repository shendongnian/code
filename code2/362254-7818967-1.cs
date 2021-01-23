    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace BufferingResponse
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Context.Response.BufferOutput = false;
                // simulate some work...
                System.Threading.Thread.Sleep(5000);
                Response.Write("<div>Another response five seconds later...</div>");
            }
        }
    }
