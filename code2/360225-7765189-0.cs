    public abstract class BasePage : Page
    {
        // Note:
        // 1. check on init, not on load
        // 2. override protected method, not handle event
        protected override OnInit(EventArgs e)
        {
            // check permissions here
        }
    }
