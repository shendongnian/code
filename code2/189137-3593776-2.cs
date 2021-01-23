    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		Label lbl = new Label();
    		lbl.Text = "This is sample text";
    		lbl.ForeColor = System.Drawing.Color.Red;
    		string html = RenderControl(lbl);
    		Response.Clear();
    		Response.Write(HttpUtility.HtmlEncode(html));
    		Response.End();
    	}
    	public string RenderControl(Control ctrl)
    	{
    		StringBuilder sb = new StringBuilder();
    		StringWriter tw = new StringWriter(sb);
    		HtmlTextWriter hw = new HtmlTextWriter(tw);
    
    		ctrl.RenderControl(hw);
    		return sb.ToString();
    	}
    }
