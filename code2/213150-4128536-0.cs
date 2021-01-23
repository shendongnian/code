    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        if (this.timer1.Enabled == false)
        {
            this.timer1.Interval = 5000;
            this.timer1.Enabled = true;
        }
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        MessageBox.Show("Shutdown!");
    }
    
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        timer1.Enabled = false;
    }
