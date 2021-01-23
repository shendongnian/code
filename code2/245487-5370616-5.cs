    using System;
    namespace TestWebApp1
    {
    	public partial class Default : System.Web.UI.Page
    	{
    	    protected void Page_Load(object sender, EventArgs e)
    	    {
    	        lblTest.Text = "Modified from Default.aspx's Page_Load method.";
    	    }
    	}
    }
