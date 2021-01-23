    using System;
    using System.Web.Services;
    
    namespace TemplateWebMethod
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            [WebMethod]
            public static string MyMethod()
            {
                return DateTime.Now.ToString();
            }
        }
    }
