        private int updateCount;
        private System.Threading.Timer timer;
        public Form1()
        {
            this.InitializeComponent();
            this.timer = new System.Threading.Timer(this.UpdateValue);
        }
        private void UpdateValue(object state)
        {
            // Prevent the user from changing the value while we're doing
            // our expensive operation
            this.Invoke(new MethodInvoker(() => this.trackBar1.Enabled = false));
            // Do the expensive updates - this is still on a background thread
            this.updateCount++;
            this.Invoke(new MethodInvoker(this.UpdateUI));
        }
        private void UpdateUI()
        {
            this.label1.Text = this.updateCount.ToString();
            // Re-enable the track bar again
            this.trackBar1.Enabled = true;
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.timer.Change(TimeSpan.FromMilliseconds(500), new TimeSpan(-1));
        }
    }
