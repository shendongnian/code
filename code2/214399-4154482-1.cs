    public class HomePage : Page
    {
        public void ChangeStatus(newStatus)
        {
            // Remember to cast this.Master to the class you use for the masterpage.
            ((SiteMaster)this.Master).StatusText = newStatus;
        }
    }
