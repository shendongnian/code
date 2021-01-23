    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool[] array = new bool[10];
            for (int i = 1; i <= 10; i++)
            {
                array[i] = ((CheckBox)Page.FindControl("CheckBox" + i.ToString())).Checked;
            }
        }
    }
