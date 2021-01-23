    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    
    
    /// <summary>
    /// Summary description for class_stylesheet
    /// </summary>
    public class class_stylesheet
    {
    	public class_stylesheet()
    	{
    		//
    		// TODO: Add constructor logic here
    		//
    	}
    
    
    
        public static void set_style_sheet_layout1(object sender, EventArgs e)
        {
            //<link href="dark.css" rel="stylesheet" type="text/css" id="stylesheet" />
    
            HtmlLink styleLink = new HtmlLink();
            styleLink.Attributes.Add("rel", "stylesheet");
            styleLink.Attributes.Add("type", "text/css");
            //styleLink.Href = "http://mydomain.com/css/mystylesheet.css";
            styleLink.Href = "LAYOUT1.css";
            Page the_page = new Page();
            //this.Page.Header.Controls.Add(styleLink);
            the_page = (Page)sender;
            the_page.Header.Controls.Add(styleLink);
        }//set style sheet
    
    
    
    
    
    
    
    }
