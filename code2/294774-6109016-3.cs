    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
    
        }
        [WebMethod]
        public static string getTime()
        {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }
    
    }
