        public Form1() {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }
        protected override void OnFormClosed(FormClosedEventArgs e) {
            Application.Idle -= Application_Idle;
            base.OnFormClosed(e);
        }
        void Application_Idle(object sender, EventArgs e) {
            var box = this.ActiveControl as TextBoxBase;
            copyToolStripMenuItem.Enabled = box != null && box.Text.Length > 0;
            cutToolStripMenuItem.Enabled = copyToolStripMenuItem.Enabled;
            pasteToolStripMenuItem.Enabled = box != null && Clipboard.ContainsText();
        }
