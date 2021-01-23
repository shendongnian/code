     public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btn10Chars_Click(object sender, EventArgs e)
        {
            lblOutput.Text = txtInput.Text.Length > 10 ? txtInput.Text.Substring(0, 10) : txtInput.Text + "  : length is less than 10 chars...";
        }
    }
