    private void timer1_Tick(object sender, EventArgs e)
    {
     if (enableButtons = false)
     {
         button1.Enabled = false;
         button2.Enabled = false;
     }
     else
     {
         button1.Enabled = true;
         button2.Enabled = true;
     }
    }
