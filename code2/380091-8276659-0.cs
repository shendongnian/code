    public partial class YourASPPage : System.Web.UI.Page
    {
            protected string Alert = "";
            protected void Page_Load(object sender, EventArgs e)
            {
                  Alert = "<script type='text/javascript'>alert('something alerted here');</script>";
            }
    }
