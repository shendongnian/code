       private System.Windows.Forms.Timer timer1; 
       private int counter = 60;
       private void btnStart_Click_1(object sender, EventArgs e)
       {
            int counter = 60;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            lblCountDown.Text = counter.ToString();
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer1.Stop();
            lblCountDown.Text = counter.ToString();
        }
