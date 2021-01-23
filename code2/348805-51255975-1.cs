        public ParentForm()
        {
            InitializeComponent();
			MyUserControl1 control1 = new MyUserControl1();
            control1.Dock = DockStyle.Bottom;
            control1.BringToFront();
        }
		private void button1_Click(object sender, EventArgs e)
        {
            MyUserControl2 control2 = new MyUserControl2();
            control2.Dock = DockStyle.Bottom;
            control2.BringToFront();
        }
