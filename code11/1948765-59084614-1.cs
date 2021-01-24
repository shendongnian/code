    //create a property
    public Timer timer { get; set; } = new Timer();
    private void BtnStart_Click(object sender, EventArgs e)
    {
        //when you click it it will be to opposite
        timer.Enabled = !timer.Enabled
    }
    int c = 0;
    private void Timer1_Tick(object sender, EventArgs e)
    {
        //while it is true
        while(timer.Enabled)
        {
            c++;
            lblTimer.Text = c.ToString();
         }
    }
