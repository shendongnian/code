    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections.Specialized;
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                NameValueCollection n = Request.QueryString;
                int x = 0;
                Response.Write("<script>");
                foreach (string s in n)
                {
                    // 3
                    // Get first key and value
                    string k = n.GetKey(x);
                    string v = n.Get(x);
                    // 4
                    // Test different keys
                    Response.Write("console.log('[" + k + "] => ");
                    Response.Write(v + "');");
                    x++;
                }
                if (x == 0)
                {
                    Response.Write("console.log('QueryString is empty!')");
                }
                Response.Write("</script>");
            }
        }
    }
