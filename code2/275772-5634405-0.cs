    public Form2()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Asterisk;
            notifyIcon1.DoubleClick += new EventHandler(notifyIcon1_DoubleClick);// to bring it back
            this.Resize += new EventHandler(Form2_Resize);// to move it to tray
        }
    
        void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }
    
        void Form2_Resize(object sender, EventArgs e)
        {
            if (this.WindowState ==FormWindowState.Minimized)
                Hide();
        }
