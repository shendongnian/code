        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            numericUpDown1.Value++;
    
        }
