        public Form1()
        {
            InitializeComponent();
            // When window state changed, trigger state update.
            this.Resize += SetMinimizeState;
            // When tray icon clicked, trigger window state change.       
            systemTrayIcon.Click += ToggleMinimizeState;
        }      
        // Toggle state between Normal and Minimized.
        private void ToggleMinimizeState(object sender, EventArgs e)
        {    
            bool isMinimized = this.WindowState == FormWindowState.Minimized;
            this.WindowState = (isMinimized) ? FormWindowState.Normal : FormWindowState.Minimized;
        }
        // Show/Hide window and tray icon to match window state.
        private void SetMinimizeState(object sender, EventArgs e)
        {    
            bool isMinimized = this.WindowState == FormWindowState.Minimized;
            this.ShowInTaskbar = !isMinimized;           
            systemTrayIcon.Visible = isMinimized;
            if (isMinimized) systemTrayIcon.ShowBalloonTip(500, "Application", "Application minimized to tray.", ToolTipIcon.Info);
        }
