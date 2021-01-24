     public partial class ChangeForAllCheckbox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                changeForAll.Checked = ...;
            }
        }
        protected void changeForAll_OnCheckedChanged(object sender, EventArgs e)
        {
            [...]
        }
    }
 
