    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var txtSearch = (TextBox)PreviousPage.Master.FindControl("txtSearch");
            if (txtSearch != null)
            {
                var value = txtSearch.Text;
                ...
            }
        }
    }
