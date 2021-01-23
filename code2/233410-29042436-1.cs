    class MainForm : Form
    {
        private SystemMenu systemMenu;
        public MainForm()
        {
            InitializeComponent();
            // Create instance and connect it with the Form
            systemMenu = new SystemMenu(this);
            // Define commands and handler methods
            // (Deferred until HandleCreated if it's too early)
            // IDs are counted internally, separator is optional
            systemMenu.AddCommand("&About…", OnSysMenuAbout, true);
        }
        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            // Let it know all messages so it can handle WM_SYSCOMMAND
            // (This method is inlined)
            systemMenu.HandleMessage(ref msg);
        }
        // Handle menu command click
        private void OnSysMenuAbout()
        {
            MessageBox.Show("My about message");
        }
    }
