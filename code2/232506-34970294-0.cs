    public Form1()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(Form1_WindowStateTrigger);
        }
        private void Form1_WindowStateTrigger(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                MessageBox.Show("FORM1 MINIMIZED!");
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                MessageBox.Show("FORM1 RESTORED!");
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                MessageBox.Show("FORM1 MAXIMIZED!");
            }
        }
