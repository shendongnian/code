    public partial class MyControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Do the update on the controls that are in the update panel
            if(CheckBox1.Checked)
                lblMessage.Text = "Hello";
            else
                lblMessage.Text = "Goodbye";
        }
    }
