    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        // ...
        public static void SetEmployeeMenu(MasterPage master)
        {
            // do whatever you want on master page
            ((SiteMaster)master).EmployeeMenu.Style.Add("display", "");
        }
    }
