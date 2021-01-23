    private Timer timer;
        private void rect_MouseEnter(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Start();
            timer.Tick += new EventHandler(t_Tick);
        }
        
        private void rect_MouseLeave(object sender, EventArgs e)
        {
            timer.Dispose();
        }
        void t_Tick(object sender, EventArgs e)
        {
            timer.Dispose();
            MessageBox.Show(@"It has been over for 3 seconds");
        }
