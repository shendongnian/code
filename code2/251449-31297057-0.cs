    myTimer.Enabled = true; 
    myTimer.Interval = 1000;
    private void myTimer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss");            
        }
