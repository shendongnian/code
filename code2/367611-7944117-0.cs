    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient; 
    
    public partial class ExportGridView : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
    
            Response.AddHeader("content-disposition", "attachment;
            filename=FileName.xls");
    
            Response.Charset = "";
    
            // If you want the option to open the Excel file without saving than
    
            // comment out the line below
    
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
    
            Response.ContentType = "application/vnd.xls";
    
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    
            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);
    
            GridView1.RenderControl(htmlWrite);
    
            Response.Write(stringWrite.ToString());
    
            Response.End();
    
        }
    }
