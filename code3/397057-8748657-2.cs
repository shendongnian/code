    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(PreviousPage.IsCrossPagePostBack)
            {
                var tb = PreviousPage.FindControl("TextBox1") as TextBox;
                Label1.Text = tb.Text;
            }
        }
    }
