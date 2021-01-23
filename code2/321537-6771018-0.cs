    public partial class UserControls_WebUserControl1 : System.Web.UI.UserControl, INotifyParent
    {
        public event CommandEventHandler NotifyParentEvent;
        private void NotifyParent(string message)
        {
            if (NotifyParentEvent != null)
            {
                CommandEventArgs e = new CommandEventArgs("Control1 Action", message);
                NotifyParentEvent(this, e);
            }
        }
    }
