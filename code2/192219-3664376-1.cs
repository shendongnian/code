    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace StackOverflowRepeater
    {
    	public partial class Default : System.Web.UI.Page
    	{
    		protected override void OnInit(EventArgs e)
    		{
    			repeater.ItemDataBound += HandleRepeaterItemDataBound;
    
    			var data = new List<string>();
    
    			if (!data.Any())
    			{
    				data.Add("No Row Found");
    			}
    
    			repeater.DataSource = data;
    			repeater.DataBind();
    
    			base.OnInit(e);
    		}
    
    		void HandleRepeaterItemDataBound (object sender, RepeaterItemEventArgs e)
    		{
    			if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item))
    			{
    				var span = (HtmlGenericControl) e.Item.FindControl("output");
    				span.InnerText = e.Item.DataItem.ToString();
    			}
    		}
    	}
    }
