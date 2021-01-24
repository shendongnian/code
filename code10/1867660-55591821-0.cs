    private int m_ntimeLeft;
    private void btnStart_Click(object sender, EventArgs e)
    {
        //Rather than getting from a text box. You can
        //hardcode as 00:03:00 since your requirement is 3 minutes
        string[] totalSeconds = txtTotalTime.Text.Split(':');
        
       //You can Avoid Hours if not required.
       int nHours = Convert.ToInt32(totalSeconds[0]);
       int nMinutes = Convert.ToInt32(totalSeconds[1]);
       int nSeconds = Convert.ToInt32(totalSeconds[2]);
       m_ntimeLeft = (nHours * 60 * 60) + (nMinutes * 60) + nSeconds;
       timerCountDown.Enabled = true;
       timerCountDown.Start();
       btnStart.Enabled = false;
       btnStop.Enabled = true;
    }
    private void timerCountDown_Tick(object sender, EventArgs e)
    {
        if (m_ntimeLeft > 0)
        {
           m_ntimeLeft = m_ntimeLeft - 1;
           var timespan = TimeSpan.FromSeconds(m_ntimeLeft);
           lblCounter.Text = timespan.ToString(@"hh\:mm\:ss");                
         }
         else
         {
            timerCountDown.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            txtTotalTime.Text = "00:00:00";
                
            //Call Stop Game Function
            MessageBox.Show("Time's up..!", "Notification", MessageBoxButtons.OK);    
          }
     }
     private void btnStop_Click(object sender, EventArgs e)
     {
        timerCountDown.Enabled = false;
        timerCountDown.Stop();
        btnStart.Enabled = true;
        lblCounter.Text = "00:00:00";
        btnStop.Enabled = false;
     }
