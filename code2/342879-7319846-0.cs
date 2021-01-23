    public delegate void UserControl2Delegate(object sender, EventArgs e);
    public partial class UserControl2 : System.Web.UI.UserControl
    {
        public event UserControl2Delegate UserControl2Event;
        //Button click to invoke the event
        protected void Button_Click(object sender, EventArgs e)
        {
            if (UserControl2Event != null)
            {
                UserControl2Event(this, new EventArgs());
            }
        }
    }
