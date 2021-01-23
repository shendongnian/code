    using System;
    using System.Web.UI;
    
    namespace WebApplication2
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                string locationName = "Mumbai";
    
                Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "addScript", "PassValues('" + locationName + "')", true);
            }
        }
    }
