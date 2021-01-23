    public class ExtendedTabPage : TabPage
    {
        public UserControl1 UserControl { get; private set; }
    
        public ExtendedTabPage(UserControl1 userControl)
        {
            UserControl = userControl;
            this.Controls.Add(userControl);
        }
    }
