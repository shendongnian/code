    namespace Demos.StackOverflow.MasterPages
    {
        using System.Web.UI;
        // This parent class inherits System.Web.UI.Page. This avoids code duplication.
        public class PageWithStatus : Page
        {
            protected void ChangeStatus(string newStatus)
            {
                ((SiteMaster)this.Master).StatusText = newStatus;
            }
        }
    }
