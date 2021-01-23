    public class BasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            base.OnLoad(e);
        }
    }
