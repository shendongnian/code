    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Load triggered");
        }
        protected void ddlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("event triggered");
            tb.Text = (sender as DropDownList).SelectedValue;
        }
    }
