    using System;
    using System.Web.UI;
    
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    	string v = Request.QueryString["Param1"];
    	if (v != null)
    	{
    	    Response.Write("param is ");
    	    Response.Write(v);
    	}
        }
    }
