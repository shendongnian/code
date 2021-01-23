     public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                var ctrl = sender as WebControl;
                if (!HasButtonBeenClicked(ctrl.ClientID))
                {
                    Response.Write("Click accepted");
                }
                else
                {
                    Response.Write("You have clicked this already!");
                }
            }
    
            private bool HasButtonBeenClicked(string controlId)
            {
                if (Request.Cookies["has_clicked_"+ controlId] != null)
                {
                    return true;
                }
                var cookie = new HttpCookie("has_clicked_" + controlId);
                Response.Cookies.Add(cookie);
                return false;
            }
    
    
        }
