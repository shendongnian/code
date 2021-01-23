    using System.Configuration;
    // all other using as required.
    public partial class Admin_UserControls_GridDisplay : System.Web.UI.UserControl
    {
        public static string smUserName = ConfigurationManager.AppSettings["smUserName"].ToString();
        public static string smPassword= ConfigurationManager.AppSettings["smPassword"].ToString();
    }
