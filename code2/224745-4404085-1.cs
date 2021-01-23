    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient;
    using System.Threading;
    using System.IO;
    using System.Reflection;
    public partial class csresults : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
       
        gridview1.DataSource = Session["dsource"];
        gridview1.DataBind();
        
    }
      public override void VerifyRenderingInServerForm(Control control)
    {
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        HtmlForm form = new HtmlForm();
        string attachment = "attachment; filename=Patients.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter stw = new StringWriter();
        HtmlTextWriter htextw = new HtmlTextWriter(stw);
        form.Controls.Add(gridview1);
        this.Controls.Add(form);
        form.RenderControl(htextw);
        Response.Write(stw.ToString());
        Response.End();
    }
    }
