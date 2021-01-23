    private void btnStartWatch_Click(object sender, EventArgs e)
    {
        timer1.Enabled = true;
    }
    
    private void btnPauseWatch_Click(object sender, EventArgs e)
    {
        timer1.Enabled = false;
    }
    
    int i = 1;
    DateTime dt = new DateTime();
    private void timer1_Tick(object sender, EventArgs e)
    {
        label1.Text = dt.AddSeconds(i).ToString("HH:mm:ss");
        i++;
    }
