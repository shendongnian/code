    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
    	public partial class temp2 : System.Web.UI.Page
    	{
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			string id = string.Empty;
    			string value = string.Empty;
    			Response.Clear();
    
    			if (Request.Form == null || Request.Form.Count < 1)
    			{
    				Response.Write("I got nothin'");
    				Response.Flush();
    				Response.End();
    				return;
    			}
    
    			id = Request.Form["id"];
    			value = Request.Form["value"];
    
    			Response.Write(string.Format("\nevent from: {0}; value={1}",id,value));
    			Response.Flush();
    			Response.End();
    		}
    	}
    }
