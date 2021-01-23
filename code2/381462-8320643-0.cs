    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoad"] == null) return;
            if (Session["isLoad"].ToString() == "1")
            {
                PlaceHolder1.Controls.Clear();
                Control CC = LoadControl("MyControl.ascx");
                PlaceHolder1.Controls.Add(CC);
            }
        }
    
        protected void Link1_Click(object sender, EventArgs e)
        {
            Session["isLoad"] = "1";
            Response.Redirect(Request.RawUrl);
        }
    }
