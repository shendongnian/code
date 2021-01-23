    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class _Default : System.Web.UI.Page
    {
    
    
    	DataTable csvData;
    	protected void Page_Load(object sender, System.EventArgs e)
    	{
    		csvData = Utils.csvToDataTable("data.csv", true);
    		GridView1.DataSource = csvData;
    		GridView1.DataBind();
    
    		Repeater1.DataSource = (from x in csvData.AsEnumerable() select x["category"]).Distinct();
    		Repeater1.DataBind();
    
    	}
    
    	private void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    	{
    		if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem) {
    			Repeater rptr = (Repeater)e.Item.FindControl("Repeater2");
    			rptr.DataSource = csvData.AsEnumerable().Where(x => x("category").Equals(e.Item.DataItem));
    			rptr.DataBind();
    		}
    	}    	
    }
