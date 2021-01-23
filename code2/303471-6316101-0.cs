    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private string _theme = "Custom";
        public string Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }
    }
    public class BasePage : System.Web.UI.Page
    {
        protected void Page_PreInit(object  sender, EventArgs e)
        {
            var siteMaster = this.Master as SiteMaster;
            if (siteMaster != null && !string.IsNullOrEmpty(siteMaster.Theme))
            {
                Theme = siteMaster.Theme;
            }
        }
    }
