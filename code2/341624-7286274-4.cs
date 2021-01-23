        using System;
        using System.Collections.Generic;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;public partial class _Default : System.Web.UI.Page 
        { 
        protected void Page_Load(object sender, EventArgs e) 
        { 
        string a = pick();
        Response.Write(a);
        }
        protected string pick() 
        { 
        string test = "I need this";
        return test;
        }
        }
