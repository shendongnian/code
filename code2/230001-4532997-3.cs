    public partial class StartupBanner : Form
    {
        private System.Windows.Forms.Timer _closeTimer = new Timer();
        public StartupBanner()
        {
            this.InitializeComponent();
            missingLabel.Text = missingNum.ToString() + " MISSING POLICIES";
            expiredLabel.Text = expiredNum.ToString() + " EXPIRED POLICIES";
            this._closeTimer = new System.Windows.Forms.Timer();
            this._closeTimer.Interval = 5000;
            this._closeTimer.Tick += new EventHandler(this._closeTimer_Tick);
            this._closeTimer.Start();
        }
        private void _closeTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
            timer.Stop();
            this.Close();
        }
    }
